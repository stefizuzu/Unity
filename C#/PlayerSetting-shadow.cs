using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour {

    Animator anim;

    [SerializeField] public float updatespeed;
    [SerializeField] public float updatestrafe;

    public float WalkSpeed = 5.0f;
    public float RunSpeed = 11.0f;

    public bool activity = false;
    public bool isDead = false;
    private bool isCoroutineExecuting = false;
    private bool kick2 = false;
    private bool punch2 = false;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (kick2) StartCoroutine("Next"); 

        Movement();
        Fight();
	}


    void Movement()
    {
        float move = Input.GetAxis("Vertical") * updatespeed;
        float strafe = Input.GetAxis("Horizontal") * updatestrafe;
        move *= Time.deltaTime;
        strafe *= Time.deltaTime;

        if (Input.GetKey(KeyCode.W) && !activity && !isDead)
        {
            updatestrafe = 100.0f;
            anim.SetFloat("speed", 1.7f);
            transform.Translate(0, 0, move);
            transform.Rotate(0, strafe, 0);
            anim.SetBool("isWalking", true);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                updatespeed = RunSpeed;
                anim.SetBool("isRunning", true);
            }
            else
            {
                updatespeed = WalkSpeed;
                anim.SetBool("isRunning", false);
            }
        }
        else if (Input.GetKey(KeyCode.S) && !activity && !isDead)
        {
            anim.SetBool("isRunning", false);
            updatespeed = 2.4f;
            updatestrafe = 50.0f;
            transform.Translate(0, 0, move);
            transform.Rotate(0, strafe, 0);
            anim.SetFloat("speed", -0.8f);
            anim.SetBool("isWalking", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetFloat("speed", -1.0f);
                updatespeed = 4.0f;
            }
         
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }
    }

    void Fight()
    {
        if (Input.GetKey(KeyCode.Mouse1)) anim.SetBool("idle_fight", true);
        else if (Input.GetKeyUp(KeyCode.Mouse1)) StartCoroutine("FinishAnimation");

        else if (Input.GetKeyDown(KeyCode.K)) StartCoroutine("Kick");
        else if (Input.GetKeyDown(KeyCode.Mouse0)) StartCoroutine("Punch");
        

        

        else
        {
            anim.SetBool("idle_fight", false);
            //activity = false;
            
        }
    }
    IEnumerator FinishAnimation()
    {
        if (isCoroutineExecuting) yield break; //if another coroutine is exec.
        isCoroutineExecuting = true; // if not
        //start
        activity = true;
        yield return new WaitForSeconds(0.25f);
        Debug.Log("Is attacking!");
        activity = false;
        StopCoroutine("FinishAnimation");
        isCoroutineExecuting = false; //stop
    }
    IEnumerator Kick()
    {
        if (isCoroutineExecuting) yield break; //if another coroutine is exec.
        isCoroutineExecuting = true; // if not
        //start
        activity = true;
        if (!kick2)
        {
            anim.SetTrigger("kick");
            kick2 = true;
        }
        else if (kick2)
        {
            yield return new WaitForSeconds(0.5f);
            anim.SetTrigger("kick2");
            kick2 = false;
        }
        yield return new WaitForSeconds(1f);
        Debug.Log("Is kicking!");
        activity = false;
        StopCoroutine("Kick");
        isCoroutineExecuting = false; //stop
    }
    IEnumerator Punch()
    {
        if (isCoroutineExecuting) yield break; //if another coroutine is exec.
        isCoroutineExecuting = true; // if not
        //start
        activity = true;
        if (!punch2)
        {
            anim.SetTrigger("punch");
            punch2 = true;
        }
        else if (punch2)
        {
            yield return new WaitForSeconds(0.5f);
            anim.SetTrigger("punch2");
            punch2 = false;
        }
        yield return new WaitForSeconds(1f);
        Debug.Log("Is punching!");
        activity = false;
        StopCoroutine("Punch");
        isCoroutineExecuting = false; //stop
    }
    IEnumerator Next()
    {
        //start
        yield return new WaitForSeconds(3.0f);
        if (kick2) kick2 = false;
        if (punch2) punch2 = false;
        StopCoroutine("Next"); 
    }
}
