using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveConsoleSphere : MonoBehaviour {

    [SerializeField]
    private Color sphereColor = Color.magenta;

    [SerializeField]
    private GameObject doorLock;

    private LockInputController lockInput;

    private float inputValue = -1;

    private void DoInputToLock() {
        lockInput.addInput(inputValue);
    }

    // Use this for initialization
    void Start () {
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = sphereColor;
        lockInput = (LockInputController)doorLock.GetComponent(typeof(LockInputController));        
    }
	
	
}
