﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockInputController : MonoBehaviour {

    [SerializeField]
    private GameObject slotMachine;

    private int[] targetInput;
    private LockCodeGenerationController lockCodeGenerationController;

    [SerializeField]
    private GameObject door;

    private AudioSource feedbackSound;

    [SerializeField]
    private AudioClip positiveFeedback, errorFeedback;

    private DoorController doorController;

    void Start() {
        targetInput = new int[4];
        resetInput();
        lockCodeGenerationController = slotMachine.GetComponent<LockCodeGenerationController>();
        doorController = door.GetComponent<DoorController>();
        feedbackSound = GetComponent<AudioSource>();
    }


    public void addInput(int value) {
		Debug.Log ("INPUT:" + value);
       

        for (int inputIndex = 0; inputIndex < targetInput.Length; inputIndex++) {
            if (targetInput[inputIndex] == -1) {
                targetInput[inputIndex] = value;
                break;
            }            
        }


        //lockCodeGenerationController.CompareCode(targetInput);
        /*string debugLine = "";
        for (int inputIndex = 0; inputIndex < targetInput.Length; inputIndex++) {
            debugLine += ("-" + targetInput[inputIndex]);
        }*/


        if (!lockCodeGenerationController.CompareCode(targetInput)) {
            Debug.Log("Wrong input");
            
            feedbackSound.clip = errorFeedback;
            feedbackSound.Play();
            resetInput();
        } else {
            Debug.Log("Correct input");
            feedbackSound.clip = positiveFeedback;             
            feedbackSound.Play();
            if (targetInput[3] != -1) {                
                doorController.OpenDoor();
            }
        }


        

        Debug.Log(lockCodeGenerationController.CompareCode(targetInput));




        //resetInput();
        /*
        if (targetInput[3] != -1) {
            lockCodeGenerationController.CompareCode(targetInput);
            string debugLine = "";
            for (int inputIndex = 0; inputIndex < targetInput.Length; inputIndex++) {
                debugLine += ("-" + targetInput[inputIndex]);
            }
            Debug.Log(debugLine);
            resetInput();
        }*/




    }

    private void resetInput() {
        for (int inputIndex = 0; inputIndex < targetInput.Length; inputIndex++) {
            targetInput[inputIndex] = -1;
        }
    }

}
