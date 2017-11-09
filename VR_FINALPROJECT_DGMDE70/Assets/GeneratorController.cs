using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour {

    [SerializeField]
    private GameObject[] shieldColliders, healthColliders;

    private GameObject[] selectedSlots;

    [SerializeField]
    private GameObject shieldIcon, healthIcon;



	
	void Start () {
        selectedSlots = new GameObject[transform.childCount];        
	}

    public void AddToken(Collider collider) {

        if (transform.GetChild(0).childCount != 0) {
            for (int childIndex = 0; childIndex < transform.childCount; childIndex++) {
                Destroy(transform.GetChild(childIndex).GetChild(0).gameObject);
            }
        }

        Transform targetLocation = null;

        for (int childIndex = 0; childIndex < transform.childCount; childIndex++) {
            if (transform.GetChild(childIndex).childCount == 0) {
                targetLocation = transform.GetChild(childIndex);
            }
        }

        
        for (int shieldIndex = 0; shieldIndex < shieldColliders.Length; shieldIndex++) {
            if (collider == shieldColliders[shieldIndex].GetComponent<Collider>()){
                GameObject shield = Instantiate(shieldIcon);
                //shield.transform.position = transform.GetChild(0).transform.position;
                shield.transform.parent = targetLocation;
                shield.transform.localPosition = Vector3.zero;
            }
        }

        for (int healthIndex = 0; healthIndex < healthColliders.Length; healthIndex++) {
            if (collider == healthColliders[healthIndex].GetComponent<Collider>()) {
                GameObject health = Instantiate(healthIcon);
                //health.transform.position = transform.GetChild(0).transform.position;
                health.transform.parent = targetLocation;
                health.transform.localPosition = Vector3.zero;
            }
        }
    }
	

}
