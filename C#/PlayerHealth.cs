using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    Animator anim;

    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }
    public float CurrentShield { get; set; }
    public float MaxShield { get; set; }

    public Slider healthbar;
    public Slider shieldbar;

    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    public bool isDead = false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();

        MaxHealth = 100.0f;
        MaxShield = 100.0f;
        CurrentHealth = MaxHealth;
        CurrentShield = MaxShield;

        healthbar.value = calcHealth();
        shieldbar.value = calcShield();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X) && !isDead) dealDamage(20);
	}

    void dealDamage(float damageValue)
    {
        anim.SetTrigger("getHit");

        if(CurrentShield == 0)
        {
            CurrentHealth -= damageValue;
            healthbar.value = calcHealth();
        }
        else
        {
            CurrentShield -= damageValue;
            shieldbar.value = calcShield();
        }
        if (CurrentHealth <= 0) Die();
    }
    float calcHealth(){
        return CurrentHealth / MaxHealth;
    }
    float calcShield(){
        return CurrentShield / MaxShield;
    }
    void Die()
    {
        isDead = true;
        CurrentHealth = 0;
        CurrentShield = 0;
        Debug.Log("You Died!");
        StartCoroutine("Respawn");
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(4);
        StopCoroutine("Respawn");
        CurrentHealth = MaxHealth;
        player.transform.position = respawnPoint.transform.position;
        healthbar.value = calcHealth();
        shieldbar.value = calcShield();
        Debug.Log("Respawned!");
        isDead = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("health"))
        {
            anim.SetTrigger("eat");
            CurrentHealth = MaxHealth;
            healthbar.value = calcHealth();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("shieldy"))
        {
            anim.SetTrigger("eat");
            CurrentShield = MaxShield;
            shieldbar.value = calcShield();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("lava"))
        {
            Die();
        }
    }
}
