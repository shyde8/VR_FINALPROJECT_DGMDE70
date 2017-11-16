using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayeVRInputController : MonoBehaviour {

	
	/*
	// Update is called once per frame
	void Update () {




        string[] values = {"A", "B", "X", "Y"};
        
        for (int valIndex = 0; valIndex < values.Length -1; valIndex++) {
            if (GetPlayerInput(values[valIndex]) != 0) {
                Debug.Log(GetPlayerInput(values[valIndex]));
            }
        }
        

    }*/

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
