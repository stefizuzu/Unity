using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryManagement : MonoBehaviour {

    public GameObject scoreManagerObject;
    public GameObject gameOverScreen;
    public GameObject blueWin;
    public GameObject redWin;
    public GameObject UI;
    public Canvas menuCanvas;
    public Canvas optionsCanvas;
    public Canvas gameOverCanvas;
    public Text redScoreUI;
    public Text blueScoreUI;
    public bool gameOver;
    string stringScoreBlue2;
    string stringScoreRed2;

    private FlagScript scoreManagerScript;

    private float scoreRed2;
    private float scoreBlue2;

    public bool cursorON;

    // Use this for initialization
    void Start () {
        cursorON = false;
        scoreManagerScript = scoreManagerObject.GetComponent<FlagScript>();
    }
    
    void OnGUI()
    {
        if (cursorON)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update () {
        scoreRed2 = GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().redScore;
        scoreBlue2 = GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().blueScore;
        //blueScoreUI.text = scoreBlue2.ToString();
        //redScoreUI.text = scoreRed2.ToString();
        redScoreUI.text = GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().redScore.ToString();
        blueScoreUI.text = GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().blueScore.ToString();

        if (menuCanvas.gameObject.activeSelf == true || optionsCanvas.gameObject.activeSelf == true || gameOverCanvas.gameObject.activeSelf == true)
        {
            cursorON = true;
        }
        if (menuCanvas.gameObject.activeSelf == false && optionsCanvas.gameObject.activeSelf == false && gameOverCanvas.gameObject.activeSelf == false)
        {
            cursorON = false;
        }

        if (scoreRed2 == 3)
        {
            gameOverScreen.SetActive(true);
            redWin.SetActive(true);
            UI.SetActive(false);
            gameOver = true;
            //cursorON = true;
        }

        if (scoreBlue2 == 3)
        {
            gameOverScreen.SetActive(true);
            blueWin.SetActive(true);
            UI.SetActive(false);
            gameOver = true;
            //cursorON = true;
        }
	}
}
