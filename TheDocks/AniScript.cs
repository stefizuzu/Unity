using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniScript : MonoBehaviour {

    Animator anim;
     
    private Vector3 PositionSample1;
    private Vector3 PositionSample2;
    private Vector3 RotationVector;

    // Use this for initialization
    void Start ()
    {
		anim = GetComponent<Animator>();
        PositionSample1 = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        PositionSample2 = PositionSample1;
        PositionSample1 = transform.position;


        if ( 90 > transform.eulerAngles.y && 0 < transform.eulerAngles.y)
        {

            Debug.Log(transform.eulerAngles.y);
            InQuad1();
        }
        else if (180 > transform.eulerAngles.y && 90 < transform.eulerAngles.y)
        {
            Debug.Log(transform.eulerAngles.y);
            InQuad2();
        }
        else if (270 > transform.eulerAngles.y && 180 < transform.eulerAngles.y)
        {
            Debug.Log(transform.eulerAngles.y);
            InQuad3();
        }
        else if (360 > transform.eulerAngles.y && 270 < transform.eulerAngles.y)
        {
            Debug.Log(transform.eulerAngles.y);
            InQuad4();
        }
        else if (transform.eulerAngles.y == 0)
        {
            Debug.Log("hello");

            
        }
        else if (transform.eulerAngles.y == 90)
        {

        }
        else if (transform.eulerAngles.y == 180)
        {

        }
        else if (transform.eulerAngles.y == 270)
        {

        }

       /* if (PositionSample1.x<PositionSample2.x)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }*/
    }

    void InQuad1()
    {
        if (PositionSample2.x - PositionSample1.x > 0)
        {
            anim.SetBool("isStrafingLeft", true);
        }
        else
        {
            anim.SetBool("isStrafingLeft", false);
        }
    }
    void InQuad2()
    {
        Debug.Log("In quad2");
    }
    void InQuad3()
    {
        Debug.Log("In quad3");
    }
    void InQuad4()
    {
        Debug.Log("In quad4");
    }

}
