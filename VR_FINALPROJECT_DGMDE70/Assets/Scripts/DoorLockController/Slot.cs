using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

    public void rotate(float face) {        
        transform.Rotate(new Vector3(90 * face,0,0));
    }
}
