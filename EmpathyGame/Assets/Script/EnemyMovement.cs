using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    Transform player;
    //PlayerHealth playerHealth;
    Health enemyHealth;
    NavMeshAgent nav;

	// Use this for initialization
	void Awake () {
        //playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <Health>();
        nav = GetComponent<NavMeshAgent>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if(enemyHealth.currentHealth > 0  /*&& playerHealth.currentHealth > 0*/)
        {			
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			if (player != null)
			{
				nav.SetDestination(player.transform.position);
			}
        }
        else
        {
        	nav.enabled = false;
        }	
	}
}
