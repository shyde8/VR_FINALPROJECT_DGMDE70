using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    [SerializeField]
    private GameObject positionTarget;

    [SerializeField]
    private float speed = 5;

    private void Update() {
        OpenDoor();
    }

    public void OpenDoor() {
        transform.position = Vector3.Lerp(transform.position, positionTarget.transform.position, Time.deltaTime);
    }
}
