using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCodeGenerationController : MonoBehaviour {

    [SerializeField]
    private GameObject[] slots;

    [SerializeField]
    private GameObject door;

    [SerializeField]
    private float delayTime = 3;

    [SerializeField]
    private int lowerCodeGenLimit = 0;
    [SerializeField]
    private int upperCodeGenLimit = 3;


    private int[] selectedFaces;

    private DoorController doorController;

    // Use this for initialization
    void Start() {
        selectedFaces = new int[slots.Length];
        StartCoroutine(rotateSlot());
        doorController = door.GetComponent<DoorController>();
    }


    public bool CompareCode(int[] code) {
        bool openDoor = true;
        for (int codeIndex = 0; codeIndex < code.Length; codeIndex++) {
            if (code[codeIndex] != -1 || code[codeIndex] != selectedFaces[codeIndex]) {
                openDoor = false;
                break;
            }
        }

        string paramLine = "";
        string codeLine = "";

        for (int inputIndex = 0; inputIndex < code.Length; inputIndex++) {
            paramLine += ("-" + code[inputIndex]);
            codeLine += ("-" + selectedFaces[inputIndex]);
        }

        Debug.Log(paramLine + " VS " + codeLine);
      

       

        return openDoor;
    }

    IEnumerator rotateSlot() {
        
        while (true) {

            for (int slotIndex = 0; slotIndex < slots.Length; slotIndex++) {
                Slot s = (Slot)slots[slotIndex].GetComponent(typeof(Slot));
                int face = Random.Range(lowerCodeGenLimit, upperCodeGenLimit);
                selectedFaces[slotIndex] = face;
                s.rotate(face);
            }
            
            yield return new WaitForSeconds(delayTime); 
        }

    }

    
	
	
}
