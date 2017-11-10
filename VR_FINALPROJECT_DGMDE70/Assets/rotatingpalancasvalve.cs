using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingpalancasvalve : MonoBehaviour {

	bool upPressed = false ;
	bool downPressed = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F))
	    {
	        upPressed = true ;
	        
	    }
	    else if(Input.GetKeyUp(KeyCode.F))
	    {
	        upPressed = false ; 
	        
	    }

	    if(upPressed == true)
    	{
    		transform.Rotate(1,0,0);
    	}

	}
}
