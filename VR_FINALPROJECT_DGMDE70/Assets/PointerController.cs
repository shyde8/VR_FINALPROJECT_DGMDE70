﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour {

    [SerializeField]
    private GameObject generator;

    private GeneratorController generatorController;

    private void Start() {
        generatorController = generator.GetComponent<GeneratorController>();
    }

    private void Update() {
      


        
       


    }

    private void OnTriggerStay(Collider other) {
       if (GetPlayerInput("A") == 2) {
            generatorController.AddToken(other);
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
