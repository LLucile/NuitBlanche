using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    Transform Player;
    //PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    NavMeshAgent nav;

	// Use this for initialization
	void Awake () {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        //playerHealth = player.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent <EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
	
	}
	
	// Update is called once per frame
	void Update () {
        //if(enemyHealth.currentHealth > 0  && playerHealth.currentHealth > 0)
        //{
        nav.SetDestination(Player.position);
        //}
        //else
        //{
        // nav.enabled = false;
        //}
	
	}
}
