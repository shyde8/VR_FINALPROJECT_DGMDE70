using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour {

    [SerializeField]
    private GameObject[] shieldColliders, healthColliders;

    private GameObject[] selectedSlots;

    [SerializeField]
    private GameObject shieldIcon, healthIcon;



	// Use this for initialization
	void Start () {
        selectedSlots = new GameObject[transform.childCount];
        
	}

    public void AddToken(Collider collider) {
        Debug.Log("1");
        for (int shieldIndex = 0; shieldIndex < shieldColliders.Length; shieldIndex++) {
            if (collider == shieldColliders[shieldIndex].GetComponent<Collider>()){
                GameObject shield = Instantiate(shieldIcon);
                shield.transform.position = transform.GetChild(0).transform.position;
            }
        }

        for (int healthIndex = 0; healthIndex < healthColliders.Length; healthIndex++) {
            if (collider == healthColliders[healthIndex].GetComponent<Collider>()) {
                GameObject health = Instantiate(healthIcon);
                health.transform.position = transform.GetChild(0).transform.position;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
