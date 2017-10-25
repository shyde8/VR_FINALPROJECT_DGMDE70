using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private float rotateSpeed = 10f;
    [SerializeField]
    private float rotationLimit = 90f;
    [SerializeField]
    private float cameraDistance = 3;
    [SerializeField]
    private float cameraRotation = 45;
    [SerializeField]
    private bool drawDistanceLine = false;
    [SerializeField]
    private Color distanceLineColor = Color.cyan;
    [SerializeField]
    private GameObject cameraModel;
    [SerializeField]
    private bool clockWiseRotation = true;

    private float direction = 1;
    private GameObject cameraRig;

    private void Start() {
        GameObject container = new GameObject();
        container.transform.rotation = transform.rotation;
        this.transform.parent = container.transform;

        cameraRig = new GameObject("cameraRig");

        if (cameraModel != null) {

            cameraModel.transform.parent = cameraRig.transform;
        }

        cameraRig.transform.parent = transform;
        cameraRig.transform.position = transform.position;
        cameraRig.transform.rotation = transform.rotation;
        cameraRig.transform.Rotate(cameraRotation, 0, 0);
        
    }

    void Update() {


        Vector3 rotationVector = transform.localRotation.eulerAngles;
        Debug.Log(rotationVector.y);

        if (rotationVector.y > rotationLimit || rotationVector.y < 0) {
            direction = direction * -1;
        }
        
        float rotation = rotateSpeed * Time.deltaTime * direction;
        transform.Rotate(new Vector3(0, rotation, 0));

        Vector3 rayOrigin = transform.position;
        Vector3 rayTarget = cameraRig.transform.forward * cameraDistance;



        if (drawDistanceLine) {
            Debug.DrawRay(rayOrigin, rayTarget, distanceLineColor);
        }
        RaycastHit targetObject;
        Physics.Raycast(rayOrigin, rayTarget, out targetObject, cameraDistance);


        if (targetObject.collider != null) {
            Debug.Log(targetObject.collider);
        }





    }
}
