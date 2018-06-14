using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour {
    
	public Animator anim1, anim2, anim3, anim4;
	private PlayerClientToServer fromServer;

	// Use this for initialization
	void Start () {
		fromServer = GetComponent<PlayerClientToServer>();
	}
	
	// Update is called once per frame
	void Update () {
		
		float player1Anima = GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player1Anim;
		float player2Anima = GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player2Anim;
		float player3Anima = GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player3Anim;
		float player4Anima = GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player4Anim;

        // Player 1 animation checks
		if(player1Anima == 1.0f) {
			anim1.SetBool("isRunning", true);
			anim1.SetBool("isBacking", false);
		}
        else if(player1Anima == 2.0f) {
			anim1.SetBool("isRunning", false);
            anim1.SetBool("isBacking", true);
		}
        else if(player1Anima == 3.0f) {
			anim1.SetBool("isStrafingLeft", true);
			anim1.SetBool("isStrafingRight", false);
		}
        else if(player1Anima == 4.0f) {
			anim1.SetBool("isStrafingLeft", false);
			anim1.SetBool("isStrafingRight", true);
		}
        else if(player1Anima == 5.0f) {
			//anim1.SetTrigger("Dying");
			anim1.SetBool("isDead", true);
		}
        else if(player1Anima == 0) {
			anim1.SetBool("isRunning", false);
            anim1.SetBool("isBacking", false);
			anim1.SetBool("isStrafingLeft", false);
			anim1.SetBool("isStrafingRight", false);
            anim1.SetBool("isDead", false);
        }

		
		if(player1Anima == 6.0f) {
			anim1.SetTrigger("isShooting");
		}

        // Player 2 animation checks
		if (player2Anima == 1.0f)
        {
            anim2.SetBool("isRunning", true);
			anim2.SetBool("isBacking", false);
        }
		else if (player2Anima == 2.0f)
        {
			anim2.SetBool("isRunning", false);
			anim2.SetBool("isBacking", true);
        }
		else if (player2Anima == 3.0f)
        {
			anim2.SetBool("isStrafingLeft", true);
			anim2.SetBool("isStrafingRight", false);
        }
		else if (player2Anima == 4.0f)
        {
			anim2.SetBool("isStrafingLeft", false);
			anim2.SetBool("isStrafingRight", true);
        }
		else if (player2Anima == 5.0f)
        {
			anim2.SetBool("isDead", true);
        }
        else if (player2Anima == 0)
        {
			anim2.SetBool("isRunning", false);
			anim2.SetBool("isBacking", false);
			anim2.SetBool("isStrafingLeft", false);
			anim2.SetBool("isStrafingRight", false);
            anim2.SetBool("isDead", false);
        }

		if (player2Anima == 6.0f)
        {
			anim2.SetTrigger("isShooting");
        }

        // Player 3 animation checks
        if (player3Anima == 1.0f)
        {
            anim3.SetBool("isRunning", true);
            anim3.SetBool("isBacking", false);
        }
        else if (player3Anima == 2.0f)
        {
            anim3.SetBool("isRunning", false);
            anim3.SetBool("isBacking", true);
        }
        else if (player3Anima == 3.0f)
        {
            anim3.SetBool("isStrafingLeft", true);
            anim3.SetBool("isStrafingRight", false);
        }
        else if (player3Anima == 4.0f)
        {
            anim3.SetBool("isStrafingLeft", false);
            anim3.SetBool("isStrafingRight", true);
        }
        else if (player3Anima == 5.0f)
        {
            anim3.SetBool("isDead", true);
        }
        else if (player3Anima == 0)
        {
            anim3.SetBool("isRunning", false);
            anim3.SetBool("isBacking", false);
            anim3.SetBool("isStrafingLeft", false);
            anim3.SetBool("isStrafingRight", false);
            anim3.SetBool("isDead", false);
        }
       
        if (player3Anima == 6.0f)
        {
            anim3.SetTrigger("isShooting");
        }

        // Player 4 animation checks
        if (player4Anima == 1.0f)
        {
            anim4.SetBool("isRunning", true);
            anim4.SetBool("isBacking", false);
        }
        else if (player4Anima == 2.0f)
        {
            anim4.SetBool("isRunning", false);
            anim4.SetBool("isBacking", true);
        }
        else if (player4Anima == 3.0f)
        {
            anim4.SetBool("isStrafingLeft", true);
            anim4.SetBool("isStrafingRight", false);
        }
        else if (player4Anima == 4.0f)
        {
            anim4.SetBool("isStrafingLeft", false);
            anim4.SetBool("isStrafingRight", true);
        }
        else if (player4Anima == 5.0f)
        {
            anim4.SetBool("isDead", true);
        }
        else if (player4Anima == 0)
        {
            anim4.SetBool("isRunning", false);
            anim4.SetBool("isBacking", false);
            anim4.SetBool("isStrafingLeft", false);
            anim4.SetBool("isStrafingRight", false);
            anim4.SetBool("isDead", false);
        }

        if (player4Anima == 6.0f)
        {
            anim4.SetTrigger("isShooting");
        }
    }
}
