using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_For_Second_Door_hyde : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (SpawnItemsBlue.hasKey==true && SpawnItemsRed.hasKey==true && SpawnItemsGreen.hasKey==true && SpawnItemsYellow.hasKey==true)
		{
			this.gameObject.GetComponent<DoorController>().OpenDoor();
		}
		
	}
}
