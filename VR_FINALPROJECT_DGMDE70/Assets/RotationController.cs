using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour {

    [SerializeField]
    private GameObject rotateOverY;	
	
	// Update is called once per frame
	void Update () {
        transform.rotation = rotateOverY.transform.rotation;
	}
}
