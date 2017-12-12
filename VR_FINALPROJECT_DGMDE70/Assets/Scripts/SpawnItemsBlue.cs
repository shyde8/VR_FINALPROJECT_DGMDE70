using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemsBlue : MonoBehaviour {

	public Transform[] SpawnPoints;
	public float spawnTime = 5.0f;
	public GameObject Coin;
	public static bool hasKey = false;

	// Use this for initialization
	void Start () 
	{
		//InvokeRepeating ("SpawnCoins", spawnTime, spawnTime);
		int spawnIndex = Random.Range (0, SpawnPoints.Length);
		if (hasKey == false) 
		{
			Instantiate (Coin, SpawnPoints [spawnIndex].position, SpawnPoints [spawnIndex].rotation);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void SpawnCoins()
	{
		/*int spawnIndex = Random.Range (0, SpawnPoints.Length);
		if (hasKey == false) 
		{
			Instantiate (Coin, SpawnPoints [spawnIndex].position, SpawnPoints [spawnIndex].rotation);
		}*/
	}
}
