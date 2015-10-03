using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    //public PlayerHealth;
    public GameObject enemy;
    public float initSpawnTime = 15f;
    private float spawnTime;
    public Transform[] spawnPoints;
    private float timer = 0f;
    private int i = 1;

	Health playerHealth;
	// Use this for initialization
	void Start () {
        spawnTime = initSpawnTime;
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<Health>();
		//InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            Invoke("Spawn", 3f);
            timer = 0;
        }
        if (Time.timeSinceLevelLoad / 30 > i)
        {
            i++;
            spawnTime -= 1;
        }
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
