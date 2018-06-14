using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth { get; set; }
    public string playerNumber;
    public bool currentlyDeadP1 = false, currentlyDeadP2 = false, currentlyDeadP3 = false, currentlyDeadP4 = false;

    public float CurrentHealth1 { get; set; }
    public float CurrentHealth2 { get; set; }
    public float CurrentHealth3 { get; set; }
    public float CurrentHealth4 { get; set; }

    public Slider healthbar1;

    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;
    [SerializeField] private Transform player3;
    [SerializeField] private Transform player4;

    [SerializeField] private Transform respawnPoint_blue;
    [SerializeField] private Transform respawnPoint_red;

    public Text deathMsg;

    void Start()
    {
        MaxHealth = 100.0f;

        CurrentHealth1 = MaxHealth;
        CurrentHealth2 = MaxHealth;
        CurrentHealth3 = MaxHealth;
        CurrentHealth4 = MaxHealth;

        healthbar1.value = calcHealth1();

        playerNumber = GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().ImPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        

        CurrentHealth1 = GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().health1;

        CurrentHealth2 = GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().health2;

        CurrentHealth3 = GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().health3;

        CurrentHealth4 = GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().health4;
       
        lifeUpdate();

        if (CurrentHealth1 != 0)
            deathMsg.text = "";
        if (CurrentHealth2 != 0)
            deathMsg.text = "";
        if (CurrentHealth3 != 0)
            deathMsg.text = "";
        if (CurrentHealth4 != 0)
            deathMsg.text = "";

		if(Input.GetKey("x")) {
			CurrentHealth1 = 0;
		}
        
    }

    void lifeUpdate()
    {
        if (playerNumber == "1")
        {
            healthbar1.value = calcHealth1();
        }
        if (playerNumber == "2")
        {
            healthbar1.value = calcHealth2();
        }
        if (playerNumber == "3")
        {
            healthbar1.value = calcHealth3();
        }
        if (playerNumber == "4")
        {
            healthbar1.value = calcHealth4();
        }
            if (CurrentHealth1 <= 0)
                Die1();   
            if (CurrentHealth2 <= 0)
                Die2(); 
            if (CurrentHealth3 <= 0)
                Die3();  
            if (CurrentHealth4 <= 0)
                Die4();
    }

    float calcHealth1()
    {
        return CurrentHealth1 / MaxHealth;
    }
    float calcHealth2()
    {
        return CurrentHealth2 / MaxHealth;
    }
    float calcHealth3()
    {
        return CurrentHealth3 / MaxHealth;
    }
    float calcHealth4()
    {
        return CurrentHealth4 / MaxHealth;
    }

    void Die1()
    {
        CurrentHealth1 = 0;
        deathMsg.text = "You Died !";
        StartCoroutine("Respawn");
    }
    void Die2()
    {
        CurrentHealth2 = 0;
        deathMsg.text = "You Died !";
        StartCoroutine("Respawn");
    }
    void Die3()
    {
        CurrentHealth3 = 0;
        deathMsg.text = "You Died !";
        StartCoroutine("Respawn");
    }
    void Die4()
    {
        CurrentHealth4 = 0;
        deathMsg.text = "You Died !";
        StartCoroutine("Respawn");
    }

    IEnumerator Respawn()
    {
        if (playerNumber == "1" && CurrentHealth1 <= 0)
        {
            GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player1Anim = 5.0f;
            currentlyDeadP1 = true;
            yield return new WaitForSeconds(15.0f);
            yield return 0;
            StopCoroutine("Respawn");

            player1.transform.position = respawnPoint_blue.transform.position;
            CurrentHealth1 = MaxHealth;
            GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player1Anim = 0;
            healthbar1.value = calcHealth1();
            currentlyDeadP1 = false;
        }
		else if (playerNumber == "2" && CurrentHealth2 <= 0)
        {
            GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player2Anim = 5.0f;
            currentlyDeadP2 = true;
            yield return new WaitForSeconds(15.0f);
            yield return 0;
            StopCoroutine("Respawn");

            player2.transform.position = respawnPoint_red.transform.position;
            CurrentHealth2 = MaxHealth;
            healthbar1.value = calcHealth2();
            GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player2Anim = 0;
            currentlyDeadP2 = false;
        }
		else if (playerNumber == "3" && CurrentHealth3 <= 0)
        {
            GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player3Anim = 5.0f;
            currentlyDeadP3 = true;
            yield return new WaitForSeconds(2.0f);
            yield return 0;
            StopCoroutine("Respawn");

            player3.transform.position = respawnPoint_blue.transform.position;
            CurrentHealth3 = MaxHealth;
            healthbar1.value = calcHealth3();
            GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player3Anim = 0;
            currentlyDeadP3 = false;
        }
		else if (playerNumber == "4" && CurrentHealth4 <= 0)
        {
            GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player4Anim = 5.0f;
            currentlyDeadP4 = true;
            yield return new WaitForSeconds(2.0f);
            yield return 0;
            StopCoroutine("Respawn");

            player4.transform.position = respawnPoint_red.transform.position;
            CurrentHealth4 = MaxHealth;
            healthbar1.value = calcHealth4();
            GameObject.Find("Player 1").GetComponent<PlayerClientToServer>().player4Anim = 0;
            currentlyDeadP4 = false;
        }
    }
}
