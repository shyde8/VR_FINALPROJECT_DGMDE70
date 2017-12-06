using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemylife : MonoBehaviour {

	Collider mycollider;
	int life = 0;
	// Use this for initialization
	void Start () {
		mycollider = GetComponent<Collider>();
		mycollider.isTrigger = false;
	}	
	
	// Update is called once per frame
	void Update () {

		if(mycollider.isTrigger == true){

			//awake();
			life = life + 1;
			mycollider.isTrigger = false;
			
			if (life ==2){
				Destroy(gameObject);
			}
		}
		
	}

}
