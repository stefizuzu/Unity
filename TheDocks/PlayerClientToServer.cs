using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using UnityEngine.Networking;

public class PlayerClientToServer : MonoBehaviour
{
    public string ipAddress = "192.168.1.64";
    //
    public float speed = 5.0F;
    public float rotationSpeed = 96.0F;
    public float strafeSpeed = 3.0f;

    public float bulletSpeed = 30.0f;
    public float bulletDestroyTime = 5.0f; // after 5-sec dissapear (bullet)

    public GameObject bulletObject;
    public Transform bulletSpawnPoint1, bulletSpawnPoint2, bulletSpawnPoint3, bulletSpawnPoint4;

    public float fire1 = 0, fire2 = 0, fire3 = 0, fire4 = 0;
    public float bulletShot1 = 0, bulletShot2 = 0, bulletShot3 = 0, bulletShot4 = 0;

    private PlayerHealth getHealth;
    public float health1 = 0, health2 = 0, health3 = 0, health4 = 0;

    public float player1Anim, player2Anim, player3Anim, player4Anim;

    public float flagPosition;

    public float blueScore = 0, redScore = 0;
    public float pointForBlue = 0, pointForRed = 0;
    public float score;

    public float player1HasTheFlag = 0, player2HasTheFlag = 0, player3HasTheFlag = 0, player4HasTheFlag = 0;
    public float whoHasTheFlag = 0;

    public Transform Player1;
    public Transform Player2;
    public Transform Player3;
    public Transform Player4;
    public Transform flagPos;

    public string ImPlayer = null;
    public float playerInGame = 0;
    float[] dataFromServer = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 };

    static Socket sock;

    // Use this for initialization
    void Start()
    {
        /*anim1 = GetComponent<Animator>();
        anim2 = GetComponent<Animator>();
        anim3 = GetComponent<Animator>();
        anim4 = GetComponent<Animator>();*/
        getHealth = GetComponent<PlayerHealth>();
        sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint IPaddress = new IPEndPoint(IPAddress.Parse(ipAddress), 13000);

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
        InvokeRepeating("Send", 1.0f, 0.1f);
        //InvokeRepeating("Shoot1", 0f, 0.250f);
    }

    void FixedUpdate()
    {
        if (ImPlayer == "1")
        {
            if (GameObject.Find("Player 1").GetComponent<PlayerHealth>().currentlyDeadP1)
            {

            }
            else
            {
                var strafing = Input.GetAxis("Horizontal") * speed;
                var forwardBack = Input.GetAxis("Vertical") * speed;
                var rotation = Input.GetAxis("Mouse X") * rotationSpeed;

                forwardBack *= Time.deltaTime;
                strafing *= Time.deltaTime;
                rotation *= Time.deltaTime;

                Player1.transform.Translate(strafing, 0, forwardBack);
                Player1.transform.Rotate(0, rotation, 0);
                health1 = getHealth.CurrentHealth1;

                //Animation if im player 1
                if (forwardBack > 0)
                {
                    player1Anim = 1.0f;
                }
                else if (forwardBack < 0)
                {
                    player1Anim = 2.0f;
                }
                else if (strafing > 0)
                {
                    player1Anim = 4.0f;
                }
                else if (strafing < 0)
                {
                    player1Anim = 3.0f;
                }
                else if (health1 <= 0)
                {
                    player1Anim = 5.0f;
                }
                else
                {
                    player1Anim = 0;
                }

                // Check for firing gun
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    fire1 = 1;
                    player1Anim = 6.0f;
                    Fire(1);
                }

                // Did other players fire?
                if (bulletShot2 == 1.0F)
                {
                    Fire(2);
                    bulletShot2 = 0;
                }
                if (bulletShot3 == 1.0F)
                {
                    Fire(3);
                    bulletShot3 = 0;
                }
                if (bulletShot4 == 1.0F)
                {
                    Fire(4);
                    bulletShot4 = 0;
                }
            }
        }
        else if (ImPlayer == "2")
        {
            if (GameObject.Find("Player 2").GetComponent<PlayerHealth>().currentlyDeadP2)
            {

            }
            else
            {
                var strafing = Input.GetAxis("Horizontal") * speed;
                var forwardBack = Input.GetAxis("Vertical") * speed;
                var rotation = Input.GetAxis("Mouse X") * rotationSpeed;

                forwardBack *= Time.deltaTime;
                strafing *= Time.deltaTime;
                rotation *= Time.deltaTime;

                Player2.transform.Translate(strafing, 0, forwardBack);
                Player2.transform.Rotate(0, rotation, 0);
                health2 = getHealth.CurrentHealth2;

                //Animation if im player 2
                if (forwardBack > 0)
                {
                    player2Anim = 1.0f;
                }
                else if (forwardBack < 0)
                {
                    player2Anim = 2.0f;
                }
                else if (strafing > 0)
                {
                    player2Anim = 4.0f;
                }
                else if (strafing < 0)
                {
                    player2Anim = 3.0f;
                }
                else if (health2 <= 0)
                {
                    player2Anim = 5.0f;
                }
                else
                {
                    player2Anim = 0;
                }

                // Check for firing gun
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    fire2 = 1;
                    Fire(2);
                }

                // Did other players fire?
                if (bulletShot1 == 1.0F)
                {
                    Fire(1);
                    bulletShot1 = 0;
                }
                if (bulletShot3 == 1.0F)
                {
                    Fire(3);
                    bulletShot3 = 0;
                }
                if (bulletShot4 == 1.0F)
                {
                    Fire(4);
                    bulletShot4 = 0;
                }
            }
        }
        else if (ImPlayer == "3")
        {

            if (GameObject.Find("Player 3").GetComponent<PlayerHealth>().currentlyDeadP3)
            {

            }
            else
            {
                var strafing = Input.GetAxis("Horizontal") * speed;
                var forwardBack = Input.GetAxis("Vertical") * speed;
                var rotation = Input.GetAxis("Mouse X") * rotationSpeed;

                forwardBack *= Time.deltaTime;
                strafing *= Time.deltaTime;
                rotation *= Time.deltaTime;

                Player3.transform.Translate(strafing, 0, forwardBack);
                Player3.transform.Rotate(0, rotation, 0);
                health3 = getHealth.CurrentHealth3;

                //Animation if im player 3
                if (forwardBack > 0)
                {
                    player3Anim = 1.0f;
                }
                else if (forwardBack < 0)
                {
                    player3Anim = 2.0f;
                }
                else if (strafing > 0)
                {
                    player3Anim = 4.0f;
                }
                else if (strafing < 0)
                {
                    player3Anim = 3.0f;
                }
                else if (health3 <= 0)
                {
                    player3Anim = 5.0f;
                }
                else
                {
                    player3Anim = 0;
                }

                // Check for firing gun
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    fire3 = 1;
                    Fire(3);
                }
                // Did other players fire?
                if (bulletShot1 == 1.0F)
                {
                    Fire(1);
                    bulletShot1 = 0;
                }
                if (bulletShot2 == 1.0F)
                {
                    Fire(2);
                    bulletShot2 = 0;
                }
                if (bulletShot4 == 1.0F)
                {
                    Fire(4);
                    bulletShot4 = 0;
                }
            }
        }
        else if (ImPlayer == "4")
        {
            if (GameObject.Find("Player 4").GetComponent<PlayerHealth>().currentlyDeadP4)
            {

            }
            else
            {
                var strafing = Input.GetAxis("Horizontal") * speed;
                var forwardBack = Input.GetAxis("Vertical") * speed;
                var rotation = Input.GetAxis("Mouse X") * rotationSpeed;

                forwardBack *= Time.deltaTime;
                strafing *= Time.deltaTime;
                rotation *= Time.deltaTime;

                Player4.transform.Translate(strafing, 0, forwardBack);
                Player4.transform.Rotate(0, rotation, 0);
                health4 = getHealth.CurrentHealth4;

                //Animation if im player 4
                if (forwardBack > 0)
                {
                    player4Anim = 1.0f;
                }
                else if (forwardBack < 0)
                {
                    player4Anim = 2.0f;
                }
                else if (strafing > 0)
                {
                    player4Anim = 4.0f;
                }
                else if (strafing < 0)
                {
                    player4Anim = 3.0f;
                }
                else if (health4 <= 0)
                {
                    player4Anim = 5.0f;
                }
                else
                {
                    player4Anim = 0;
                }

                // Check for firing gun
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    fire4 = 1;
                    Fire(4);
                }

                // Did other players fire?
                if (bulletShot1 == 1.0F)
                {
                    Fire(1);
                    bulletShot1 = 0;
                }
                if (bulletShot2 == 1.0F)
                {
                    Fire(2);
                    bulletShot2 = 0;
                }
                if (bulletShot3 == 1.0F)
                {
                    Fire(3);
                    bulletShot3 = 0;
                }
            }
        }
    }

    void Send()
    {
        if (ImPlayer == "1")
        {
            player1();
        }
        else if (ImPlayer == "2")
        {
            player2();
        }
        else if (ImPlayer == "3")
        {
            player3();
        }
        else if (ImPlayer == "4")
        {
            player4();
        }
    }

    void player1()
    {
        int i = 0;

        Vector3 postion = Player1.transform.position;
        var rotation = Player1.transform.eulerAngles.y;

        Vector3 flagPostion = flagPos.transform.position;

        string myData = postion.x + " " + postion.y + " " + postion.z + " " + rotation + " " + fire1 + " " + health1 + " " + player1Anim + " " + player1HasTheFlag + " " + player2HasTheFlag + " " + player3HasTheFlag + " " + player4HasTheFlag + " " + pointForBlue + " " + pointForRed;
        fire1 = 0;
        pointForBlue = 0;
        pointForRed = 0;

        sock.Send(System.Text.Encoding.ASCII.GetBytes(myData), 0, myData.Length, SocketFlags.None);

        byte[] MSGFromServer = new byte[1024];
        int size = sock.Receive(MSGFromServer);

        string inPut = System.Text.Encoding.ASCII.GetString(MSGFromServer, 0, size);

        string[] numbers = Regex.Split(inPut, @"\s+");

        foreach (string value in numbers)
        {
            if (!string.IsNullOrEmpty(value))
            {
                dataFromServer[i] = float.Parse(value);
                i++;
            }
        }

        Vector3 tempPositionPlayer2 = new Vector3(dataFromServer[0], dataFromServer[1], dataFromServer[2]);
        bulletShot2 = dataFromServer[4];
        health2 = dataFromServer[5];
        player2Anim = dataFromServer[6];
        whoHasTheFlag = dataFromServer[21];

        Vector3 tempPositionPlayer3 = new Vector3(dataFromServer[7], dataFromServer[8], dataFromServer[9]);
        bulletShot3 = dataFromServer[11];
        health3 = dataFromServer[12];
        player3Anim = dataFromServer[13];
        Vector3 tempPositionPlayer4 = new Vector3(dataFromServer[14], dataFromServer[15], dataFromServer[16]);
        bulletShot4 = dataFromServer[18];
        health4 = dataFromServer[19];
        player4Anim = dataFromServer[20];

        Player2.transform.position = tempPositionPlayer2;
        Player3.transform.position = tempPositionPlayer3;
        Player4.transform.position = tempPositionPlayer4;

        Player2.transform.rotation = Quaternion.Euler(0, dataFromServer[3], 0);
        Player3.transform.rotation = Quaternion.Euler(0, dataFromServer[10], 0);
        Player4.transform.rotation = Quaternion.Euler(0, dataFromServer[17], 0);

        //flagPosition = new Vector3(dataFromServer[21], dataFromServer[22], dataFromServer[23]);
        player1HasTheFlag = dataFromServer[21];
        player2HasTheFlag = dataFromServer[22];
        player3HasTheFlag = dataFromServer[23];
        player4HasTheFlag = dataFromServer[24];

        blueScore = dataFromServer[25];
        redScore = dataFromServer[26];

        playerInGame= dataFromServer[27];

        Debug.Log("Player In Game " + playerInGame);
    }

    void player2()
    {
        int i = 0;

        Vector3 postion = Player2.transform.position;
        var rotation = Player2.transform.eulerAngles.y;

        Vector3 flagPostion = flagPos.transform.position;

        string myData = postion.x + " " + postion.y + " " + postion.z + " " + rotation + " " + fire2 + " " + health2 + " " + player2Anim + " " + player1HasTheFlag + " " + player2HasTheFlag + " " + player3HasTheFlag + " " + player4HasTheFlag + " " + pointForBlue + " " + pointForRed;
        fire2 = 0;
        pointForBlue = 0;
        pointForRed = 0;

        sock.Send(System.Text.Encoding.ASCII.GetBytes(myData), 0, myData.Length, SocketFlags.None);

        byte[] MSGFromServer = new byte[1024];
        int size = sock.Receive(MSGFromServer);

        string inPut = System.Text.Encoding.ASCII.GetString(MSGFromServer, 0, size);

        string[] numbers = Regex.Split(inPut, @"\s+");

        foreach (string value in numbers)
        {
            if (!string.IsNullOrEmpty(value))
            {
                dataFromServer[i] = float.Parse(value);
                i++;
            }
        }

        Vector3 tempPositionPlayer1 = new Vector3(dataFromServer[0], dataFromServer[1], dataFromServer[2]);
        bulletShot1 = dataFromServer[4];
        health1 = dataFromServer[5];
        player1Anim = dataFromServer[6];
        whoHasTheFlag = dataFromServer[21];

        Vector3 tempPositionPlayer3 = new Vector3(dataFromServer[7], dataFromServer[8], dataFromServer[9]);
        bulletShot3 = dataFromServer[11];
        health3 = dataFromServer[12];
        player3Anim = dataFromServer[13];
        Vector3 tempPositionPlayer4 = new Vector3(dataFromServer[14], dataFromServer[15], dataFromServer[16]);
        bulletShot4 = dataFromServer[18];
        health4 = dataFromServer[19];
        player4Anim = dataFromServer[20];

        Player1.transform.position = tempPositionPlayer1;
        Player3.transform.position = tempPositionPlayer3;
        Player4.transform.position = tempPositionPlayer4;

        Player1.transform.rotation = Quaternion.Euler(0, dataFromServer[3], 0);
        Player3.transform.rotation = Quaternion.Euler(0, dataFromServer[10], 0);
        Player4.transform.rotation = Quaternion.Euler(0, dataFromServer[17], 0);

        //flagPosition = new Vector3(dataFromServer[21], dataFromServer[22], dataFromServer[23]);
        player1HasTheFlag = dataFromServer[21];
        player2HasTheFlag = dataFromServer[22];
        player3HasTheFlag = dataFromServer[23];
        player4HasTheFlag = dataFromServer[24];

        blueScore = dataFromServer[25];
        redScore = dataFromServer[26];

        playerInGame = dataFromServer[27];
        Debug.Log("Player In Game " + playerInGame);
    }

    void player3()
    {
        int i = 0;

        Vector3 postion = Player3.transform.position;
        var rotation = Player3.transform.eulerAngles.y;

        Vector3 flagPostion = flagPos.transform.position;

        string myData = postion.x + " " + postion.y + " " + postion.z + " " + rotation + " " + fire3 + " " + health3 + " " + player3Anim + " " + player1HasTheFlag + " " + player2HasTheFlag + " " + player3HasTheFlag + " " + player4HasTheFlag + " " + pointForBlue + " " + pointForRed;
        fire3 = 0;
        pointForBlue = 0;
        pointForRed = 0;

        sock.Send(System.Text.Encoding.ASCII.GetBytes(myData), 0, myData.Length, SocketFlags.None);

        byte[] MSGFromServer = new byte[1024];
        int size = sock.Receive(MSGFromServer);

        string inPut = System.Text.Encoding.ASCII.GetString(MSGFromServer, 0, size);

        string[] numbers = Regex.Split(inPut, @"\s+");

        foreach (string value in numbers)
        {
            if (!string.IsNullOrEmpty(value))
            {
                dataFromServer[i] = float.Parse(value);
                i++;
            }
        }

        Vector3 tempPositionPlayer1 = new Vector3(dataFromServer[0], dataFromServer[1], dataFromServer[2]);
        bulletShot1 = dataFromServer[4];
        health1 = dataFromServer[5];
        player1Anim = dataFromServer[6];
        whoHasTheFlag = dataFromServer[21];

        Vector3 tempPositionPlayer2 = new Vector3(dataFromServer[7], dataFromServer[8], dataFromServer[9]);
        bulletShot2 = dataFromServer[11];
        health2 = dataFromServer[12];
        player2Anim = dataFromServer[13];
        Vector3 tempPositionPlayer4 = new Vector3(dataFromServer[14], dataFromServer[15], dataFromServer[16]);
        bulletShot4 = dataFromServer[18];
        health4 = dataFromServer[19];
        player4Anim = dataFromServer[20];

        Player1.transform.position = tempPositionPlayer1;
        Player2.transform.position = tempPositionPlayer2;
        Player4.transform.position = tempPositionPlayer4;

        Player1.transform.rotation = Quaternion.Euler(0, dataFromServer[3], 0);
        Player2.transform.rotation = Quaternion.Euler(0, dataFromServer[10], 0);
        Player4.transform.rotation = Quaternion.Euler(0, dataFromServer[17], 0);

        //flagPosition = new Vector3(dataFromServer[21], dataFromServer[22], dataFromServer[23]);
        player1HasTheFlag = dataFromServer[21];
        player2HasTheFlag = dataFromServer[22];
        player3HasTheFlag = dataFromServer[23];
        player4HasTheFlag = dataFromServer[24];

        blueScore = dataFromServer[25];
        redScore = dataFromServer[26];

        playerInGame = dataFromServer[27];
        Debug.Log("Player In Game " + playerInGame);
    }

    void player4()
    {
        int i = 0;

        Vector3 postion = Player4.transform.position;
        var rotation = Player4.transform.eulerAngles.y;
        Vector3 flagPostion = flagPos.transform.position;

        string myData = postion.x + " " + postion.y + " " + postion.z + " " + rotation + " " + fire4 + " " + health4 + " " + player4Anim + " " + player1HasTheFlag + " " + player2HasTheFlag + " " + player3HasTheFlag + " " + player4HasTheFlag + " " + pointForBlue + " " + pointForRed;
        fire4 = 0;
        pointForBlue = 0;
        pointForRed = 0;

        sock.Send(System.Text.Encoding.ASCII.GetBytes(myData), 0, myData.Length, SocketFlags.None);

        byte[] MSGFromServer = new byte[1024];
        int size = sock.Receive(MSGFromServer);

        string inPut = System.Text.Encoding.ASCII.GetString(MSGFromServer, 0, size);

        string[] numbers = Regex.Split(inPut, @"\s+");

        foreach (string value in numbers)
        {
            if (!string.IsNullOrEmpty(value))
            {
                dataFromServer[i] = float.Parse(value);
                i++;
            }
        }

        Vector3 tempPositionPlayer1 = new Vector3(dataFromServer[0], dataFromServer[1], dataFromServer[2]);
        bulletShot1 = dataFromServer[4];
        health1 = dataFromServer[5];
        player1Anim = dataFromServer[6];
        whoHasTheFlag = dataFromServer[21];

        Vector3 tempPositionPlayer2 = new Vector3(dataFromServer[7], dataFromServer[8], dataFromServer[9]);
        bulletShot2 = dataFromServer[11];
        health2 = dataFromServer[12];
        player2Anim = dataFromServer[13];
        Vector3 tempPositionPlayer3 = new Vector3(dataFromServer[14], dataFromServer[15], dataFromServer[16]);
        bulletShot3 = dataFromServer[18];
        health3 = dataFromServer[19];
        player3Anim = dataFromServer[20];

        Player1.transform.position = tempPositionPlayer1;
        Player2.transform.position = tempPositionPlayer2;
        Player3.transform.position = tempPositionPlayer3;

        Player1.transform.rotation = Quaternion.Euler(0, dataFromServer[3], 0);
        Player2.transform.rotation = Quaternion.Euler(0, dataFromServer[10], 0);
        Player3.transform.rotation = Quaternion.Euler(0, dataFromServer[17], 0);

        blueScore = dataFromServer[25];
        redScore = dataFromServer[26];

        playerInGame = dataFromServer[27];
        Debug.Log("Player In Game " + playerInGame);
    }

    void Fire(int whoFired)
    {
        // Create the Bullet from the Bullet Prefab
        if (whoFired == 1)
        {
            var bullet = (GameObject)Instantiate(
           bulletObject,
           bulletSpawnPoint1.position,
           bulletSpawnPoint1.rotation);

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

            Destroy(bullet, bulletDestroyTime);
        }
        else if (whoFired == 2)
        {
            //
            var bullet = (GameObject)Instantiate(
           bulletObject,
           bulletSpawnPoint2.position,
           bulletSpawnPoint2.rotation);

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

            Destroy(bullet, bulletDestroyTime);
        }
        else if (whoFired == 3)
        {
            var bullet = (GameObject)Instantiate(
           bulletObject,
           bulletSpawnPoint3.position,
           bulletSpawnPoint3.rotation);

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

            Destroy(bullet, bulletDestroyTime);
        }
        else if (whoFired == 4)
        {
            var bullet = (GameObject)Instantiate(
           bulletObject,
           bulletSpawnPoint4.position,
           bulletSpawnPoint4.rotation);

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

            Destroy(bullet, bulletDestroyTime);
        }
    }

    private void OnApplicationQuit()
    {
        Debug.Log("exit");
        string myData = "exit";
        sock.Send(System.Text.Encoding.ASCII.GetBytes(myData), 0, myData.Length, SocketFlags.None);
        sock.Close();
    }
}