using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
public class bulletClient : MonoBehaviour {

    public float bulletSpeed = 10.0f;
    public float bulletDestroyTime = 5.0f; // after 5-sec dissapear (bullet)
    public GameObject bulletObject;
    public Transform bulletSpawnPoint;

    public Transform bulletz;

    string ImPlayer = null;
    float[] dataFromServer = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    static Socket sock;

    // Use this for initialization
    void Start () {
        sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint IPaddress = new IPEndPoint(IPAddress.Parse("192.168.1.132"), 13000);

        try
        {
            sock.Connect(IPaddress);
        }
        catch
        {
            Debug.Log("Unable to connect");
        }


        byte[] MSGFromServer = new byte[1024];
        int size = sock.Receive(MSGFromServer);

        string inPut = System.Text.Encoding.ASCII.GetString(MSGFromServer, 0, size);
        Debug.Log("Jag ar player " + inPut);
        ImPlayer = inPut;
        InvokeRepeating("Send", 1.0f, 0.125f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
