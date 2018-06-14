using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeMovement : MonoBehaviour {
	private float oldValue, newValue;
	public float testMovement = 0.1F;
	public float testRotate = 5.0F;
	public Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log(rb.velocity.x);
		//transform.Translate(testMovement, 0, 0);
		if(transform.position.x > 25.0F && 27.0F > transform.position.x) {
			transform.Rotate(0, testRotate, 0);
		}
	}
}
