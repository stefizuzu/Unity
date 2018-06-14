using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSetting : MonoBehaviour
{
    public GameObject victoryManagementObject;

    // (slow speed if have flag)
    private FlagScript carryFlag;
    public GameObject flag;
    private bool flagON;

	[SerializeField]
	Behaviour[] componentsToDisable;

    Animator anim;
    public float speed = 5.0F;
    public float effectiveRotationSpeed = 96.0F;
    public float realRotationSpeed = 96.0f;
    public float strafeSpeed = 3.0f;

    public float speedUpdate;
    public float strafeSpeedUpdate;

    private PlayerHealth healthManagement;
    private VictoryManagement victoryManagement;

    public bool allowGameInteraction = true;
    private float currentHealth;
    private bool gameOver;
    private bool cursorON;

    // weapon variables
    public float bulletSpeed = 10.0f;
    public float bulletDestroyTime = 5.0f; // after 5-sec dissapear (bullet)
    public GameObject bulletObject;
    public Transform bulletSpawnPoint;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        carryFlag = flag.GetComponent<FlagScript>();
        flagON = carryFlag.flagTaken;

        anim = GetComponent<Animator>();
        healthManagement = gameObject.GetComponent<PlayerHealth>();
        victoryManagement = victoryManagementObject.GetComponent<VictoryManagement>();

		for (int i = 0; i < 2; i++) {
			componentsToDisable[i].enabled = false;
		}
    }

    // Update is called once per frame
    void Update()
    {
		flagON = carryFlag.flagTaken;
        //currentHealth = healthManagement.CurrentHealth;
        gameOver = victoryManagement.gameOver;
        cursorON = victoryManagement.cursorON;
        if (currentHealth <= 0 || gameOver == true)
        {
            allowGameInteraction = false;
        }
        else
        {
            allowGameInteraction = true;
        }
        if (allowGameInteraction == true)
        {
            Movement();
            //Shoot();
        }
        if(cursorON == true)
        {
            effectiveRotationSpeed = 0f;
        }
        if(cursorON == false)
        {
            effectiveRotationSpeed = realRotationSpeed;
        }
    }
   

    /*void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

			anim.SetTrigger("isShooting");
            var bullet = (GameObject)Instantiate(
            bulletObject,
            bulletSpawnPoint.position,
            bulletSpawnPoint.rotation);

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

			Destroy(bullet, bulletDestroyTime);

        }
       
    }*/
    
    public void changeRotationSpeed(float mouseSensitivity)
    {
        realRotationSpeed = mouseSensitivity;
    }


    void Movement() {
        if (flagON)
        {
            speedUpdate = 2.0f;
            strafeSpeedUpdate = 0.6f;
        }
        else
        {
            speedUpdate = speed;
            strafeSpeedUpdate = strafeSpeed;
        }
        float movVertical = Input.GetAxis("Vertical") * speedUpdate;
        float strafing = Input.GetAxis("Horizontal") * strafeSpeedUpdate;
        float rotation = Input.GetAxis("Mouse X") * effectiveRotationSpeed;

        movVertical *= Time.deltaTime;
        strafing *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, movVertical);
        transform.Rotate(0, rotation, 0);
        transform.Translate(strafing, 0, 0);
        

        // Animation booleans for player movement
        if (movVertical > 0) {
            //Debug.Log("position x = " + transform.position.x);
            //Debug.Log("position z = " + transform.position.z);
            anim.SetBool("isRunning", true);
            anim.SetBool("isBacking", false);
        } else if(movVertical < 0) {
            //Debug.Log("position x = " + transform.position.x);
            //Debug.Log("position z = " + transform.position.z);
            anim.SetBool("isRunning", false);
           anim.SetBool("isBacking", true);
        }
        else if(strafing > 0) {
            anim.SetBool("isStrafingRight", true);
            anim.SetBool("isStrafingLeft", false);
        } else if(strafing < 0) {
            //Debug.Log("position x = " + transform.position.x);
            //Debug.Log("position z = " + transform.position.z);
            anim.SetBool("isStrafingRight", false);
            anim.SetBool("isStrafingLeft", true);
        } else {
            //Debug.Log("position x = " + transform.position.x);
            //Debug.Log("position z = " + transform.position.z);
            anim.SetBool("isShooting", false);
            anim.SetBool("isStrafingRight", false);
            anim.SetBool("isStrafingLeft", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isBacking", false);
        }
    }

}
