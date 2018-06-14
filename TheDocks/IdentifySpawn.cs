using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentifySpawn : MonoBehaviour {

    public bool InBlueTeamSpawn = false;
    public bool InRedTeamSpawn = false;

    void OnCollisionEnter(Collision collision)
    {
        string colName = collision.gameObject.name;
        if(colName=="BlueTeamSpawn")
        {
            InBlueTeamSpawn = true;
            InRedTeamSpawn = false;
        }
        else if(colName == "RedTeamSpawn")
        {
            InBlueTeamSpawn = false;
            InRedTeamSpawn = true;
        }
        else
        {
            InBlueTeamSpawn = false;
            InRedTeamSpawn = false;
        }
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	
}
