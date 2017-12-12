using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectsRed : MonoBehaviour {

	public float destroyTime = 5.0f;
	public float rotateSpeed = 40f;

	// Use this for initialization
	void Start () 
	{
		//Destroy (gameObject, destroyTime);
	}

	void Update()
	{
		transform.Rotate (Vector3.forward * Time.deltaTime * rotateSpeed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PVR") 
		{
			Destroy (gameObject);
			SpawnItemsRed.hasKey = true;
		}
	}


}
