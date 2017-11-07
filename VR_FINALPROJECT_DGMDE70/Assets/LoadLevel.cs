using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadLevel : MonoBehaviour {

    [SerializeField]
    private string sceneName;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("LOAD");

        //Application.LoadLevel(sceneName);
        SceneManager.LoadScene(sceneName);
        
        //AssetBundle loadedAssets = AssetBundle.LoadFromFile("Assets/scenes/" + sceneName);
        //string[] scenePaths = loadedAssets.GetAllScenePaths();
    }
}
