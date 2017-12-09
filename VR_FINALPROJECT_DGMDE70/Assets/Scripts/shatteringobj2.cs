using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shatteringobj2 : MonoBehaviour {
	Collider mycollider;
	public GameObject myjarron2destruido;
	// Use this for initialization
	void Start () {
		mycollider = GetComponent<Collider>();
		mycollider.isTrigger = false;

	}
	// Update is called once per frame
	void Update () {
		if(mycollider.isTrigger == true){
			Instantiate(myjarron2destruido, transform.position, transform.rotation);
			Destroy(gameObject);
		}	}
}
