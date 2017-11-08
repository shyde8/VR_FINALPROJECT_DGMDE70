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

    private void OnTriggerEnter(Collider other) {

        if (Input.GetKeyDown("1")) {
            generatorController.AddToken(other);
        }
    }
}
