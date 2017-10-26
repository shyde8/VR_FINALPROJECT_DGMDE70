using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour {

    public GameObject[] cube;
        
	// Use this for initialization
	void Start () {
        StartCoroutine("rotat");
	}

    IEnumerator rotat() {

        while (true) {
            for (int x = 0; x < cube.Length; x++) {
                Slot s = (Slot)cube[x].GetComponent(typeof(Slot));
                s.rotate();
            }
            
            yield return new WaitForSeconds(3f); 
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
