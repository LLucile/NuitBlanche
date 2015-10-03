﻿using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    //public PlayerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	
	}

    void Spawn()
    {
        // if( playerHealth <= 0 )
        //{
        // return;
        //}
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
	
}
