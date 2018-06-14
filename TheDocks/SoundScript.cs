using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour {

    public AudioClip[] StepSound;
    private AudioSource source;
    private int StepSoundindex = 0;
    private bool OnContainer = false;
    private float volume = 0.5f;

    /*void OnCollisionEnter(Collision collision)
    {

        string colName = collision.gameObject.name;
        if (colName == "concrete_slab" || colName == "warehouse_1")
        {
            OnContainer = false;
        }
        else
        {
            OnContainer = true;
        }
    }*/


    // Use this for initialization
    void Awake ()
    {
        source = GetComponent<AudioSource>();
    }
	
    void RunningSoundStep(float value = 1.0f)
    {
       
        StepSoundindex = Random.Range(0, 10);
        volume = 0.5f;
        
        source.PlayOneShot(StepSound[StepSoundindex], volume);
    }
    

    void StrafeStepSound(float value = 1.0f)//same function strafe left and right currently all funktions have the same sound effects. 
    {
        StepSoundindex = Random.Range(11, 14);
        source.PlayOneShot(StepSound[StepSoundindex], 0.1f);
    }

    void Shooting(float value = 1.0f)
    {
        StepSoundindex = Random.Range(15, 19);
        source.PlayOneShot(StepSound[StepSoundindex], 0.5f);
    }

    void IsLandingSoundngSound(float value = 1.0f)
    {
        source.PlayOneShot(StepSound[20], 0.5f);
    }

}
