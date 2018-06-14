using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerIPAddress : MonoBehaviour {

    public static string IPAddressStatic;
    public InputField IPInputField;
	// Use this for initialization
	void Start () {
		
	}
	
    public void pass()
    {
        IPAddressStatic = IPInputField.text;
    }

	// Update is called once per frame

}
