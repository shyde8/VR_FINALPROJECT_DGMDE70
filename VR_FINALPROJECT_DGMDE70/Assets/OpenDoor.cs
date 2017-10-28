using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    [SerializeField]
    private GameObject door;
	
	// Update is called once per frame
	void Update () {
		
	}

    public void openDoor() {
        door.transform.Translate(new Vector3(0,-100,0));
    }
}
