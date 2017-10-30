using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondRotationController : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        StartCoroutine(AnimateDiamond());
	}

    IEnumerator AnimateDiamond() {
        transform.Rotate(new Vector3(0, 1, 0));
        yield return new WaitForSeconds(1);

    }
}
