using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        
	}

    

    private void OnCollisionEnter(Collision collision) {
        rotate();
    }

    

    public void rotate() {
        float face = Random.RandomRange(1, 4);
        transform.Rotate(new Vector3(90 * face,0,0));
    }
}
