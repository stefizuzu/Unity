using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript : MonoBehaviour
{

    public int imPlayer;

    public Rigidbody rbFlag;
    public Rigidbody targetCenter;

    private IdentifySpawn isPlayerHomeScript;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    private PlayerHealth HealthScript;

	public float whoHasFlag;

    private bool inSpawnBoolBlue;
    private bool inSpawnBoolRed;
    public bool flagTaken = false;
    private Vector3 offsetFlag = new Vector3(0, 1.5f, 0);
    public Transform BlueSpawnCenter;
    public Transform RedSpawnCenter;
    public int scoreRed;
    public int scoreBlue;
    private int spawnPointsIncrement = 0;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BlueSpawn")
        {
			flagTaken = false;
            transform.position = Vector3.MoveTowards(transform.position, BlueSpawnCenter.position, 10000 * Time.deltaTime);
            
            if (imPlayer == whoHasFlag)
            {
                scoreBlue++;
                GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().pointForBlue = 1;
                transform.position = new Vector3(25f, 1.07f, 60); // spawn flag
                                                                 //StartCoroutine("RespawnFlag");
                                                                 // whoHasFlag = 0;
                GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player1HasTheFlag = 0;
            }
            else
                transform.position = new Vector3(25f, 1.07f, 60); // spawn flag
                                                                 //StartCoroutine("RespawnFlag");
        }

        if (collision.gameObject.tag == "RedSpawn")
        {
            flagTaken = false;
			transform.position = Vector3.MoveTowards(transform.position, RedSpawnCenter.position, 10000 * Time.deltaTime);
			
            if(imPlayer == whoHasFlag)
            {
                scoreRed++;
                GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().pointForRed = 1;
                //StartCoroutine("RespawnFlag");
                transform.position = new Vector3(25f, 1.07f, 60); // spawn flag
                //whoHasFlag = 0;
                GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player1HasTheFlag = 0;
            }
            else
                transform.position = new Vector3(25f, 1.07f, 60); // spawn flag
                //StartCoroutine("RespawnFlag");
        }

		if (collision.gameObject.tag == "Player 1")
		{
			flagTaken = true;
			transform.position = Player1.transform.position + offsetFlag;
            //whoHasFlag = 1;
            GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player1HasTheFlag = 1;
        }
		else if (collision.gameObject.tag == "Player 2")
		{
			flagTaken = true;
			transform.position = Player2.transform.position + offsetFlag;
            //whoHasFlag = 2;
            GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player1HasTheFlag = 2;
        }
		else if (collision.gameObject.tag == "Player 3")
		{
			flagTaken = true;
			transform.position = Player3.transform.position + offsetFlag;
            //whoHasFlag = 3;
            GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player1HasTheFlag = 3;
        }
		else if (collision.gameObject.tag == "Player 4")
		{//
			flagTaken = true;
			transform.position = Player4.transform.position + offsetFlag;
            //whoHasFlag = 4;
            GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player1HasTheFlag = 4;
        }
        else
        {
            flagTaken = false;
            transform.position = new Vector3(25f, 1.1f, 60); // spawn flag
            GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player1HasTheFlag = 0;
        }

    }
    [SerializeField] private Transform flagRespwan;
    //[SerializeField] private Transform respawnPoint;

    public Transform spawnPosition;
    private Transform[] childs;
    private GameObject randomSpawns;

	IEnumerator RespawnFlag()
    {
        yield return new WaitForSeconds(2f);
        yield return 0;
        StopCoroutine("RespawnFlag");

        Transform[] childs = (Transform[])spawnPosition.GetComponentsInChildren<Transform>(); // gets transform of spawnPositions children
        GameObject randomSpawns = (GameObject)((Transform)childs[0]).gameObject; // randomly picks a childs transform
        flagTaken = false;
        //whoHasFlag = 0;
        GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player1HasTheFlag = 0;

        //flagRespwan.transform.position = randomSpawns.gameObject.transform.position; // spawn player at random spawn
        transform.position = new Vector3(25f, 1.07f, 60); // spawn player at random spawn
    }
    void Start()
    {
        transform.position = new Vector3(25f, 1.07f, 60);
    }
    void Update()
    {
        imPlayer = int.Parse(GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().ImPlayer);
        whoHasFlag = GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().whoHasTheFlag;
        float p1health = GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().health1;
		float p2health = GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().health2;
		float p3health = GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().health3;
		float p4health = GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().health4;

		if(transform.position.y < 0) {
			flagTaken = false;
            rbFlag.AddForce((targetCenter.position - transform.position) * 5);
		}

		if(whoHasFlag != 0) {
			flagTaken = true;
		}
        if (whoHasFlag == 0)
        {
            flagTaken = false;
        }

        if (flagTaken)
        {
            //inSpawnBoolBlue = isPlayerHomeScript.InBlueTeamSpawn;
            //inSpawnBoolRed = isPlayerHomeScript.InRedTeamSpawn;
           
			switch ((int) whoHasFlag) {
				case 1:
					transform.position = Player1.transform.position + offsetFlag;
					break;
				case 2:
					transform.position = Player2.transform.position + offsetFlag;
					break;
				case 3:
					transform.position = Player3.transform.position + offsetFlag;
					break;
				case 4:
					transform.position = Player4.transform.position + offsetFlag;
					break;
				default:
                    //whoHasFlag = 0;
                    GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player1HasTheFlag = 0;
                    break;
			}

			if (p1health <= 0)
            {
                flagTaken = false;
                rbFlag.AddForce((targetCenter.position - transform.position) * 5);
				GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player1HasTheFlag = 0;
            }
            if (p2health <= 0)
            {
                flagTaken = false;
                rbFlag.AddForce((targetCenter.position - transform.position) * 5);
				GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player1HasTheFlag = 0;
            }
            if (p3health <= 0)
            {
                flagTaken = false;
                rbFlag.AddForce((targetCenter.position - transform.position) * 5);
				GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player1HasTheFlag = 0;
            }
            if (p4health <= 0)
            {
                flagTaken = false;
                rbFlag.AddForce((targetCenter.position - transform.position) * 5);
				GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player1HasTheFlag = 0;
            }
        }
    }
}
