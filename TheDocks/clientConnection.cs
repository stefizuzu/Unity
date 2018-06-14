using UnityEngine;
using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;

public class clientConnection : MonoBehaviour {

    static Socket sock;
	public Transform player1, player2;
	public int playerNr, receivedB;

	public float[] dataFromServer = new float[] 
	{ 
		0, 0, 0, 
		0, 0, 0 
	};

	public string quitString, Player1Pos, stringPos, Player2Pos;

	// Use this for initialization
	void Start () {
		sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint IPaddress = new IPEndPoint(IPAddress.Parse("130.229.133.56"), 8891);

        try
        {
            sock.Connect(IPaddress);
        }
        catch
        {
            Debug.Log("Unable to connect");
        }
        byte[] data2 = new byte[255];
        int rec = sock.Receive(data2, 0, data2.Length, 0);
        Array.Resize(ref data2, rec);
        
        playerNr = Int32.Parse(Encoding.Default.GetString(data2));
        Debug.Log("You are player " + playerNr);

		InvokeRepeating("sendPlayerData", 1.0f, 0.125f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch(playerNr) {
			case 1: 
				Player1Pos = player1.position.ToString();
				break;
			case 2:
				Player2Pos = player2.position.ToString();
				break;
		}
	}

	void sendPlayerData()
	{
		switch (playerNr)
        {
            case 1:
				sendPlayer1Data();
				break;
			case 2:
				sendPlayer2Data();
				break;
            default:
				break;
        }
	}

    void sendPlayer1Data()
	{
		if (Input.GetKey("q")) {
            quitString = "Quit";
            byte[] quitByte = Encoding.Default.GetBytes(quitString);
            sock.Send(quitByte);
            sock.Shutdown(SocketShutdown.Both);
            sock.Close();
		} else {
			byte[] dataPos = Encoding.ASCII.GetBytes(Player1Pos);
            sock.Send(dataPos);

            byte[] received = null;
            received = new byte[1024];
            receivedB = sock.Receive(received);
            byte[] data10 = new byte[receivedB];
            Array.Copy(received, data10, receivedB);
            //receivedB = sock.Receive(received, 0, received.Length, 0);
            //Array.Resize(ref received, receivedB);
			Player2Pos = Encoding.ASCII.GetString(received);

            int i = 0;
			string[] numbers = Regex.Split(Player2Pos, @"\s+");
            foreach (string value in numbers) {
                if (!string.IsNullOrEmpty(value)) {
                    //Debug.Log(value);
                    dataFromServer[i] = float.Parse(value);
                    i++;
                }
            }

			Vector3 tempPosition = new Vector3(dataFromServer[3], dataFromServer[4], dataFromServer[5]);
            //Debug.Log("Hittat " + dataFromServer[3] + dataFromServer[4] + dataFromServer[5]);
            player2.transform.position = tempPosition;
		}
	}

	void sendPlayer2Data()
	{
		byte[] dataPos = Encoding.ASCII.GetBytes(stringPos);
        sock.Send(dataPos);

        byte[] received = null;
        received = new byte[1024];
        receivedB = sock.Receive(received);
        byte[] data10 = new byte[receivedB];
        Array.Copy(received, data10, receivedB);
        //receivedB = sock.Receive(received, 0, received.Length, 0);
        //Array.Resize(ref received, receivedB);
		Player2Pos = Encoding.ASCII.GetString(received);

        int i = 0;
		string[] numbers = Regex.Split(Player2Pos, @"\s+");
        foreach (string value in numbers) {
                if (!string.IsNullOrEmpty(value)) {
                    Debug.Log(value);
                    dataFromServer[i] = float.Parse(value);
                    i++;
                }
        }

        Vector3 tempPosition = new Vector3(dataFromServer[0] + 5, dataFromServer[1], dataFromServer[2]);
        //Debug.Log("Hittat " + dataFromServer[0] + dataFromServer[1] + dataFromServer[2]);
        player2.transform.position = tempPosition;
	}
}
