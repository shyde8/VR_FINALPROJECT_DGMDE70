using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour {

   

    [SerializeField]
    private GameObject[] regiteredColliders;

    private GameObject[] selectedSlots;
    private int[] slotValues;

    [SerializeField]
    private GameObject shieldIcon, healthIcon, errorScreen;

    [SerializeField]
    private AudioClip positiveFeedbackSound, negativeFeedbackSound;

    private AudioSource collitionFeedbackSound;



    private int shieldValue = 1, healthValue = 2;


	
	void Start () {
        collitionFeedbackSound = GetComponent<AudioSource>();
        selectedSlots = new GameObject[transform.childCount];
        slotValues = new int[transform.childCount];
        
    }

    public void AddToken(Collider collider) {

       

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
        

        //Check what is the value of the input
        ShieldGeneratorColliderValue value = collider.GetComponent<ShieldGeneratorColliderValue>();
        Debug.Log(value.value);


       

        if (value.value == shieldValue) {
            GameObject shield = Instantiate(shieldIcon);
            shield.transform.parent = targetLocation;
            shield.transform.localPosition = Vector3.zero;
            slotValues[positionIndex] = shieldValue;
        } else if (value.value == healthValue) {
            GameObject health = Instantiate(healthIcon);            
            health.transform.parent = targetLocation;
            health.transform.localPosition = Vector3.zero;
            slotValues[positionIndex] = healthValue;
        }

        if (positionIndex > 0 && slotValues[positionIndex] != slotValues[positionIndex - 1]) {

            collitionFeedbackSound.clip = negativeFeedbackSound;
            collitionFeedbackSound.Play();
            resetGenerator();
            errorScreen.SetActive(true);
            StartCoroutine(reEnable());
        } else {
            collitionFeedbackSound.clip = positiveFeedbackSound;
            collitionFeedbackSound.Play();
        }



        if (slotValues[transform.GetChildCount() - 1] == shieldValue) {
            Debug.Log("ADD A SHIELD POINT");            
            resetGenerator();
        } else if (slotValues[transform.GetChildCount() - 1] == healthValue) {            
            Debug.Log("ADD A HEALTH POINT");
            resetGenerator();
        }

       

    }

    IEnumerator reEnable() {
        yield return new WaitForSeconds(1);
        errorScreen.SetActive(false);

    }

    private void resetGenerator() {
        for (int childIndex = 0; childIndex < transform.childCount; childIndex++) {
            if (transform.GetChild(childIndex).childCount > 0) {
                Destroy(transform.GetChild(childIndex).GetChild(0).gameObject);
                slotValues[childIndex] = 0;
            } else {
                break;
            }                     
        }
    }
}
