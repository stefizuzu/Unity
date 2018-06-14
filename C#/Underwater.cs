using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Underwater : MonoBehaviour {
    public PostProcessingProfile normal, fx;
    private PostProcessingBehaviour camImageFx;

	// Use this for initialization
	void Start () {
        camImageFx = FindObjectOfType<PostProcessingBehaviour>();
	}

    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            camImageFx.profile = fx;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            camImageFx.profile = normal;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
  
}
