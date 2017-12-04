﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour {

	public Transform[] SpawnPoints;
	public float spawnTime = 5.0f;
	public GameObject[] Coins;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("SpawnCoins", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void SpawnCoins()
	{
		int spawnIndex = Random.Range (0, SpawnPoints.Length);
		Instantiate (Coins[0], SpawnPoints [spawnIndex].position, SpawnPoints [spawnIndex].rotation);
	}
}
