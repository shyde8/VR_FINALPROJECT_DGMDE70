using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HealthController : MonoBehaviour {

	[SerializeField]private float health = 100;
    [SerializeField]
    private bool isBoss;
	public void ApplyDamage(float damage)
	{
		health -= damage;

		if (health <= 0f){

            if (isBoss) {
                SceneManager.LoadScene("level_2");
            }
			Destroy (gameObject);
		}
	}


}
