using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadLevel : MonoBehaviour {

    [SerializeField]
    private string sceneName;

    private void OnTriggerEnter(Collider other) {              
        SceneManager.LoadScene(sceneName);              
    }
}
