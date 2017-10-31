using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveConsoleSphere : MonoBehaviour {

    [SerializeField]
    private Color sphereColor = Color.magenta;

    [SerializeField]
    private GameObject doorLock;

    [SerializeField]
    private int inputValue = -1;

    private LockInputController lockInput;

    public void DoInputToLock() {
        lockInput.addInput(inputValue);
    }

    // Use this for initialization
    void Start () {
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = sphereColor;
        lockInput = transform.parent.gameObject.GetComponent<LockInputController>();
        //lockInput = (LockInputController)doorLock.GetComponent(typeof(LockInputController));        
    }
	
	
}
