using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockInputController : MonoBehaviour {

    private float[] targetInput;

    void Start() {
        targetInput = new float[4];
        resetInput();
    }


    public void addInput(float value) {

        if (targetInput[3] != -1) {
            resetInput();
        }
        for (int inputIndex = 0; inputIndex < targetInput.Length; inputIndex++) {
            if (targetInput[inputIndex] == -1) {
                targetInput[inputIndex] = value;
            }
        }

    }

    private void resetInput() {
        for (int inputIndex = 0; inputIndex < targetInput.Length; inputIndex++) {
            targetInput[inputIndex] = -1;
        }
    }

}
