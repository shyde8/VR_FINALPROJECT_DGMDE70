using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateopenvalve : MonoBehaviour {
	bool upPressed = false ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.G))
	    {
	        upPressed = true ;
	        
	    }
	    else if(Input.GetKeyUp(KeyCode.G))
	    {
	        upPressed = false ; 
	        
	    }

	    if(upPressed == true)
    	{
    		transform.Rotate(0,-1,0);
    	}
	}
}
