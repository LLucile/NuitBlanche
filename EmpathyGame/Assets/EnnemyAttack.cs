using UnityEngine;
using System.Collections;

public class EnnemyAttack : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth  = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
	}

    // Use this for trigger event
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    //Use this for trigger event out
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth>0)
        {
            Attack();
        }
        if (playerHealth.currentHealth <= 0)
        {
            //stop moving : player is dead
        }	
	}

    void Attack()
    {
        timer = 0f;
        if (playerHealth.currentHealth > 0)
        {
            //Send damages to player
        }
    }
}


