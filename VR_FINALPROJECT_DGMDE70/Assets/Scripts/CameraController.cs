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

    [SerializeField]
    private GameObject enemy;

    private float direction = 1;
    private GameObject cameraRig;
    private Color originalColor;

    

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

        originalColor = RenderSettings.ambientLight;

    }

    void Update() {


        Vector3 rotationVector = transform.localRotation.eulerAngles;
        
        
        if ( clockWiseRotation && rotationVector.y > rotationLimit) {
            direction = direction * -1;
        } else  if (!clockWiseRotation && rotationVector.y < (360 - rotationLimit)) {
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
            if (targetObject.collider.CompareTag("PVR")) {
               
                
            }
            
            
        }

    }


    private void OnTriggerEnter(Collider other) {
        Debug.Log("TRI");
        if (other.CompareTag("PVR")) {
            GameObject ne = Instantiate(enemy);
            ne.gameObject.transform.position = transform.position;
            ne.GetComponent<EnemyController>().SetPlayer(other.gameObject);
            
            StartCoroutine(TriggerAlarm());
        }
    }


    IEnumerator TriggerAlarm() {
        
        RenderSettings.ambientLight = Color.red;
        yield return new WaitForSeconds(1);
        Debug.Log(originalColor);
        RenderSettings.ambientLight = originalColor;
    }
}
