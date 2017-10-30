using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour {

    [SerializeField]
    private GameObject[] slots;

    [SerializeField]
    private float delayTime = 3;

    private float[] selectedFaces;
        
	// Use this for initialization
	void Start () {
        selectedFaces = new float[slots.Length];
        StartCoroutine(rotateSlot());
	}

    IEnumerator rotateSlot() {
        
        while (true) {

            for (int slotIndex = 0; slotIndex < slots.Length; slotIndex++) {
                Slot s = (Slot)slots[slotIndex].GetComponent(typeof(Slot));
                float face = Random.Range(1, 4);
                Debug.Log(face);
                selectedFaces[slotIndex] = face;
                s.rotate(face);
            }
            
            yield return new WaitForSeconds(delayTime); 
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
