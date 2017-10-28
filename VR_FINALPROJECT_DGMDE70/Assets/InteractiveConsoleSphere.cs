using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveConsoleSphere : MonoBehaviour {

    [SerializeField]
    private Color sphereColor = Color.magenta;

    
	// Use this for initialization
	void Start () {
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = sphereColor;        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
