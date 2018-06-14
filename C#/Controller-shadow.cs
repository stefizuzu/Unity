using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    #region Variables
    Animator anim;
    [SerializeField] public float updatespeed;
    [SerializeField] public float updatestrafe;

    public float WalkSpeed = 5.0f;
    public float RunSpeed = 11.0f;

    public bool activity = false;
    public bool isDead = false;
    private bool isCoroutineExecuting = false;
    private bool crouch = false;
    private bool punch2 = false;
    #endregion 

    void Start () {
        anim = GetComponent<Animator>();
    }

	void Update () {
        Movement();
        if (!Input.GetKey(KeyCode.W) || isDead) anim.SetBool("crouchwalk", false);
    }
    void Movement()
    {
        float move = Input.GetAxis("Vertical") * updatespeed;
        float strafe = Input.GetAxis("Horizontal") * updatestrafe;
        move *= Time.deltaTime;
        strafe *= Time.deltaTime;

         if (Input.GetKeyDown(KeyCode.LeftControl) && !isDead) StartCoroutine("Crouch");
        else if (Input.GetKey(KeyCode.W) && !activity && !isDead)
        {
            updatestrafe = 100.0f;
            anim.SetFloat("speed", 1.7f);
            transform.Translate(0, 0, move);
            transform.Rotate(0, strafe, 0);
            anim.SetBool("isWalking", true);

            
             if (crouch)
            {
                updatespeed = 3.0f;
                anim.SetBool("crouchwalk", true);
            } 

            else if (Input.GetKey(KeyCode.LeftShift))
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
            anim.SetBool("isBacking", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetFloat("speed", -1.0f);
                updatespeed = 4.0f;
            }

        }
        
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isBacking", false);
            anim.SetBool("isRunning", false);
        }
    }
    IEnumerator Crouch()
    {
        //start
        activity = true;

        if (!crouch)
        {
            anim.SetBool("crouch", true);
            crouch = true;

        }
        else if (crouch)
        {
            anim.SetBool("crouch", false);
            crouch = false;
        }

        yield return new WaitForSeconds(1.0f);
        activity = false;
        StopCoroutine("Crouch");
    }
}
