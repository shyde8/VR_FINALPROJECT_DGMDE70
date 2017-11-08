using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGeneratorUnit : MonoBehaviour {

    [SerializeField]
    private GameObject leftLimit, rightLimit, pointer;

    [SerializeField]
    private float speedMin= 0.1f, speedMax = 0.5f, proximityLimit = 0.5f;

    private GameObject directionLimit;


    private void Start() {
        directionLimit = leftLimit;
    }

    void Update () {

        

        if (Vector3.Distance(pointer.transform.position, directionLimit.transform.position) < proximityLimit) {
            

            if (directionLimit == leftLimit) {
                directionLimit = rightLimit;
            } else {
                directionLimit = leftLimit;
            }
        }
        pointer.transform.position = Vector3.Lerp(pointer.transform.position, directionLimit.transform.position, Time.deltaTime * (Random.Range(speedMin, speedMax)));
	}
}
