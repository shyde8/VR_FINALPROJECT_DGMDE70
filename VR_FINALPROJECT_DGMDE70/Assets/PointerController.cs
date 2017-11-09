using System.Collections;
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
       
        if (Input.GetButtonDown("PSCR_A")) {
            generatorController.AddToken(other);
        }
    }

  
}
