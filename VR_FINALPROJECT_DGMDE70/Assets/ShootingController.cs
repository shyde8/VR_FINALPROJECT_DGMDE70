using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour {

    [SerializeField]
    private float distance = 5;

    [SerializeField]
    private GameObject pointer;


    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit raycastHitInfo;

        Physics.Raycast(transform.position, transform.forward, out raycastHitInfo, distance);

        if (raycastHitInfo.collider) {
            Debug.Log(raycastHitInfo.collider);
            pointer.transform.position = raycastHitInfo.collider.transform.position;
            pointer.transform.Translate(new Vector3(0,-1f,0));
          //  GameObject.Destroy(raycastHitInfo.collider.transform.gameObject);
        }

        if (Input.GetMouseButtonDown(0)) {
            Debug.DrawLine(transform.position, transform.forward, Color.red);
        }
        
	}
}
