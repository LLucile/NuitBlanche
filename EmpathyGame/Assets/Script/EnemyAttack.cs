using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    Animator anim;
    GameObject player;
	Health playerHealth;
    Health enemyHealth;
    bool playerInRange;
    float timer;
	Vector3 collisionPoint;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<Health>();
		enemyHealth  = GetComponent<Health>();
		anim = GetComponent<Animator>();
	}

	// Use this for trigger event
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
			collisionPoint = other.ClosestPointOnBounds(transform.position);
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
			Attack(collisionPoint);
		}
		if (playerHealth.currentHealth <= 0)
        {
            //stop moving : player is dead
        }	
	}

    void Attack(Vector3 collisionPoint)
    {
        timer = 0f;
        if (playerHealth.currentHealth > 0)
        {
            //Send damages to player
			playerHealth.TakeDamage(attackDamage, collisionPoint);
        }
    }
}


