using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    //public PlayerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

	Health playerHealth;
	// Use this for initialization
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<Health>();
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}

    void Spawn()
    {
        if(playerHealth.currentHealth <= 0)
        {
        	return;
        }
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
	
}
