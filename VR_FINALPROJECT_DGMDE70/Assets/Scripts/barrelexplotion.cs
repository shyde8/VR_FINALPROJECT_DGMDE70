using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelexplotion : MonoBehaviour {
	ParticleSystem myexplotion;
	Collider mycollider;
	// Use this for initialization
	void Start () {
		mycollider = GetComponent<Collider>();
		mycollider.isTrigger = false;
	}	
	
	// Update is called once per frame
	void Update () {

		if(mycollider.isTrigger == true){
			awake();

			Destroy(gameObject, 2);
		}
		
	}

	void awake(){
		myexplotion = GetComponentInChildren<ParticleSystem>();
		myexplotion.Play();
	}
	
}
