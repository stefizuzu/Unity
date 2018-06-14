using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyScript : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject error;
    public GameObject waiting;
    public GameObject startButton;
    public GameObject startButtonDisabled;

    public int nrOfPlayers = 4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //nrOfPlayers = (int) GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().playerInGame;
        switch (nrOfPlayers)
        {
            case 0:
                player1.gameObject.SetActive(false);
                player2.gameObject.SetActive(false);
                player3.gameObject.SetActive(false);
                player4.gameObject.SetActive(false);
                error.gameObject.SetActive(false);
                waiting.gameObject.SetActive(true);
                startButton.gameObject.SetActive(false);
                startButtonDisabled.gameObject.SetActive(true);
                break;
            case 1:
                player1.gameObject.SetActive(true);
                player2.gameObject.SetActive(false);
                player3.gameObject.SetActive(false);
                player4.gameObject.SetActive(false);
                error.gameObject.SetActive(false);
                waiting.gameObject.SetActive(true);
                startButton.gameObject.SetActive(false);
                startButtonDisabled.gameObject.SetActive(true);
                break;
            case 2:
                player1.gameObject.SetActive(true);
                player2.gameObject.SetActive(true);
                player3.gameObject.SetActive(false);
                player4.gameObject.SetActive(false);
                error.gameObject.SetActive(false);
                waiting.gameObject.SetActive(false);
                startButton.gameObject.SetActive(true);
                startButtonDisabled.gameObject.SetActive(false);
                break;
            case 3:
                player1.gameObject.SetActive(true);
                player2.gameObject.SetActive(true);
                player3.gameObject.SetActive(true);
                player4.gameObject.SetActive(false);
                error.gameObject.SetActive(false);
                waiting.gameObject.SetActive(false);
                startButton.gameObject.SetActive(true);
                startButtonDisabled.gameObject.SetActive(false);
                break;
            case 4:
                player1.gameObject.SetActive(true);
                player2.gameObject.SetActive(true);
                player3.gameObject.SetActive(true);
                player4.gameObject.SetActive(true);
                error.gameObject.SetActive(false);
                waiting.gameObject.SetActive(false);
                startButton.gameObject.SetActive(true);
                startButtonDisabled.gameObject.SetActive(false);
                break;
            default:
                player1.gameObject.SetActive(false);
                player2.gameObject.SetActive(false);
                player3.gameObject.SetActive(false);
                player4.gameObject.SetActive(false);
                error.gameObject.SetActive(true);
                waiting.gameObject.SetActive(false);
                startButton.gameObject.SetActive(false);
                startButtonDisabled.gameObject.SetActive(true);
                break;
        }
	}
    public void multiplayerStart()
    {
        SceneManager.LoadScene("NyaServer", LoadSceneMode.Single);
    }
}
