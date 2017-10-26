using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveConsoleSphere : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = Color.cyan;        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
