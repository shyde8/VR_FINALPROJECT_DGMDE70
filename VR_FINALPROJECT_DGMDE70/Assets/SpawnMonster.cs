using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour {

    [SerializeField]
    private GameObject enemy, player;

    public void Start() {
        StartCoroutine(TriggerAlarm());
    }

    IEnumerator TriggerAlarm() {

        while (true) {
            GameObject ne = Instantiate(enemy);
            ne.gameObject.transform.position = transform.position;
            ne.GetComponent<EnemyController>().SetPlayer(player.gameObject);
            yield return new WaitForSeconds(10);
        }
        
        
        
    }
}
