using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour {

    Animator anim;
    Animation animatzion;
    private PlayerHealth updateDeath;

    public float walkspeed = 4.0f;
    public float runspeed = 7.0f;
    public float updatespeed;
    public float updatestrafe;

    public bool isDead = false;
    public bool activity = false;

    private bool isCoroutineExecuting = false;

	// Use this for initialization
	void Start () {
        updatespeed = walkspeed;
        updatestrafe = 100.0f;

        anim = GetComponent<Animator>();
        animatzion = GetComponent<Animation>();

        updateDeath = GetComponent<PlayerHealth>();
        isDead = updateDeath.isDead;
	}
	
	// Update is called once per frame
	void Update () {
        isDead = updateDeath.isDead;
        Movement();
        Activity();
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
            transform.Translate(0,0,move);
            transform.Rotate(0, strafe, 0);
            anim.SetBool("isWalking", true);

            if(Input.GetKey(KeyCode.LeftShift))
            {
                updatespeed = runspeed;
                anim.SetBool("isRunning", true);
            }
            else
            {
                updatespeed = walkspeed;
                anim.SetBool("isRunning", false);
            }
        }
        else if (Input.GetKey(KeyCode.S) && !activity && !isDead)
        {
            updatespeed = 1.5f;
            updatestrafe = 50.0f;
            transform.Translate(0, 0, move);
            transform.Rotate(0, strafe, 0);
            anim.SetFloat("speed", -1.0f);
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false); 
            anim.SetBool("isRunning", false);
        }
    }
    void Activity()
    {
        if (Input.GetKeyDown(KeyCode.T) && !isDead) StartCoroutine("Shout");
        else if (Input.GetKeyDown(KeyCode.Space) && !isDead) StartCoroutine("Attack");
        else if (Input.GetKeyDown(KeyCode.E) && !isDead) StartCoroutine("Eat");
        else if (isDead) anim.SetBool("isDead", true);
        else if (!isDead) anim.SetBool("isDead", false);
    }
    IEnumerator Shout()
    {
        if (isCoroutineExecuting) yield break;
        isCoroutineExecuting = true; // if not

        activity = true;
        updatespeed = 0;
        anim.SetTrigger("shout");
        yield return new WaitForSeconds(6.0f);
        StopCoroutine("Shout");
        Debug.Log("Is shouting!");
        activity = false;
        isCoroutineExecuting = false;
    }
    IEnumerator Attack()
    {
        if (isCoroutineExecuting) yield break;
        isCoroutineExecuting = true; // if not

        activity = true;
        updatespeed = 0;
        anim.SetTrigger("attack");
        yield return new WaitForSeconds(1.6f);
        StopCoroutine("Attack");
        Debug.Log("Is attacking!");
        activity = false;
        isCoroutineExecuting = false;
    }
    IEnumerator Eat()
    {
        if (isCoroutineExecuting) yield break;
        isCoroutineExecuting = true; // if not

        activity = true;
        updatespeed = 0;
        anim.SetTrigger("eat");
        yield return new WaitForSeconds(2.9f);
        StopCoroutine("Eat");
        Debug.Log("Is eating!");
        activity = false;
        isCoroutineExecuting = false;
    }
    IEnumerator Die()
    {
        if (isCoroutineExecuting) yield break;
        isCoroutineExecuting = true; // if not

        yield return new WaitForSeconds(2.9f);
        StopCoroutine("Die");
        Debug.Log("Dead!");
        activity = false;
        isCoroutineExecuting = false;
    }
}
