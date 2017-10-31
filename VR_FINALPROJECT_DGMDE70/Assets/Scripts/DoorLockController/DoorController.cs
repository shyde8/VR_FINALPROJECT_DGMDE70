using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    [SerializeField]
    private GameObject positionTarget;

    [SerializeField]
    private float speed = 5;

    private bool openDoor;

    private void Update() {

        if (openDoor) {
            transform.position = Vector3.Lerp(transform.position, positionTarget.transform.position, Time.deltaTime);
        }
    }

    public void OpenDoor() {
        openDoor = true;
    }
}
