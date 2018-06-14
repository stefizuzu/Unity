using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

   

    void OnCollisionEnter(Collision collision)
    {      
		if(collision.gameObject.tag == "Player 1") {
			Debug.Log("Player 1 got hit");
			GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().health1 -= 50;
		} else if(collision.gameObject.tag == "Player 2") {
			Debug.Log("Player 2 got hit");
			GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().health2 -= 50;
		} else if(collision.gameObject.tag == "Player 3") {
			Debug.Log("Player 3 got hit");
			GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().health3 -= 50;
		} else if (collision.gameObject.tag == "Player 3") {
            Debug.Log("Player 3 got hit");
            GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().health4 -= 50;
		}
		Destroy(gameObject);
    }
}
