using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour {

    [SerializeField]
    private GameObject[] shieldColliders, healthColliders;

    private GameObject[] selectedSlots;
    private int[] slotValues;

    [SerializeField]
    private GameObject shieldIcon, healthIcon, errorScreen;



    private int shieldValue = 1, healthValue = 2;


	
	void Start () {
        
        selectedSlots = new GameObject[transform.childCount];
        slotValues = new int[transform.childCount];
        
    }

    public void AddToken(Collider collider) {

        //If the user already made 4 inputs (the element have a child) then remove all the children from the slots
        if (transform.GetChild(transform.childCount -1).childCount != 0) {
            resetGenerator();
        }

        //targetLocation is determined by the first slot found that has no child.
        Transform targetLocation = null;
        int positionIndex = -1;
        for (int childIndex = 0; childIndex < transform.childCount; childIndex++) {
            if (transform.GetChild(childIndex).childCount == 0) {
                targetLocation = transform.GetChild(childIndex);
                positionIndex = childIndex;                
                break;
            }
        }

        //What we do on these 2 iterations is determine what kind of collider was hit by the defined list
        //provided on the prefab parameters.
        for (int shieldIndex = 0; shieldIndex < shieldColliders.Length; shieldIndex++) {
            if (collider == shieldColliders[shieldIndex].GetComponent<Collider>()) {
                GameObject shield = Instantiate(shieldIcon);
                //shield.transform.position = transform.GetChild(0).transform.position;
                shield.transform.parent = targetLocation;
                shield.transform.localPosition = Vector3.zero;
                slotValues[positionIndex] = shieldValue;

            }
        }

        for (int healthIndex = 0; healthIndex < healthColliders.Length; healthIndex++) {
            if (collider == healthColliders[healthIndex].GetComponent<Collider>()) {
                GameObject health = Instantiate(healthIcon);
                //health.transform.position = transform.GetChild(0).transform.position;
                health.transform.parent = targetLocation;
                health.transform.localPosition = Vector3.zero;
                slotValues[positionIndex] = healthValue;
            }
        }

        
        for (int valuesIndex = 0; valuesIndex < transform.childCount - 2; valuesIndex++) {
            //Debug.Log(slotValues[valuesIndex]);
            //Debug.Log(slotValues[valuesIndex+1]);
            if (slotValues[valuesIndex] != slotValues[valuesIndex + 1] && slotValues[valuesIndex + 1] != 0) {
                Debug.Log("YOU MADE A MISTAKE");
                errorScreen.SetActive(true);
                resetGenerator();
            } 
        }     
    }

    private void resetGenerator() {
        for (int childIndex = 0; childIndex < transform.childCount-1; childIndex++) {
            if (transform.GetChild(childIndex).childCount > 0) {
                Destroy(transform.GetChild(childIndex).GetChild(0).gameObject);
                slotValues[childIndex] = 0;
            } else {
                break;
            }                     
        }
    }
}
