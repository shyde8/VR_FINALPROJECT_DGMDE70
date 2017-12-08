using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour {

    [SerializeField]
    private float distance = 5;

    [SerializeField]
    private float yPositionIncrease = 5;

    [SerializeField]
    private GameObject pointer;

    [SerializeField]
    private GameObject indicator;


    // Use this for initialization
    void Start () {
        indicator.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        RaycastHit raycastHitInfo;

        Physics.Raycast(transform.position, transform.forward, out raycastHitInfo, distance);

        if (raycastHitInfo.collider) {
            
            if (raycastHitInfo.collider.CompareTag("Taggable")) {
                pointer.gameObject.SetActive(true);
                pointer.transform.position = raycastHitInfo.collider.transform.position;
                pointer.transform.Translate(new Vector3(0, yPositionIncrease, 0));
                indicator.SetActive(true);
            } else {
                pointer.gameObject.SetActive(false);
                indicator.SetActive(false);
            }

            
            if (GetPlayerInput("X") == 2 || Input.GetMouseButtonDown(0)) {
                Debug.Log("Interaction player 1");
                InteractiveConsoleSphere ics = raycastHitInfo.collider.gameObject.GetComponent<InteractiveConsoleSphere>();
                if (ics != null) {                    
                    ics.DoInputToLock();
                }
                /*
                OpenDoor ods = (OpenDoor)raycastHitInfo.collider.gameObject.GetComponent(typeof(OpenDoor));
                if(ods!=null){
                    ods.openDoor();
                }
                */
            }
          //  GameObject.Destroy(raycastHitInfo.collider.transform.gameObject);
        }

        
        if (Input.GetMouseButtonDown(0)) {
            Debug.DrawLine(transform.position, transform.forward, Color.red);

        }

       

    }

    private int GetPlayerInput(string val) {
        if (IsPressed("PSCR_" + val) && IsPressed("PVR_" + val)) {
            return 1;
        } else if (!IsPressed("PVR_" + val) && IsPressed("PSCR_" + val)) {
            return 2;
        } else {
            return 0;
        }
    }

    private bool IsPressed(string val) {
        return Input.GetButtonDown(val);
    }
}
