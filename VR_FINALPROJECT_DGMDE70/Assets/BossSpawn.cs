using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour {

    [SerializeField]
    private GameObject boss;

    
    private void OnTriggerEnter(Collider other) {
        boss.SetActive(true);
    }


}
