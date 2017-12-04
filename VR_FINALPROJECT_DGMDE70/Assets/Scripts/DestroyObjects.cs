using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour {

	public float destroyTime = 5.0f;

	// Use this for initialization
	void Start () 
	{
		Destroy (gameObject, destroyTime);
	}
	

}
