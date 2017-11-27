using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour 
{
	public Image CurrentHealthBar;
	public Text ratioText;

	private float hitPoint = 100;
	private float maxHitPoint = 100;

	private void Start()
	{
		//Calling UpdateHealthBar() to start
		UpdateHealthBar();


	}

	private void UpdateHealthBar()
	{
		//gives us value between 0 and 1
		float ratio = hitPoint / maxHitPoint;

		//scale CurrentHealthBar based on ratio
		CurrentHealthBar.rectTransform.localScale = new Vector3 (ratio, 1, 1);

		ratioText.text = (ratio * 100).ToString("0") + '%';


	}

	private void TakeDamage(float damage)
	{
		hitPoint -= damage;

		//placeholder to prevent scaling issues until we come up with GameOver scenario
		if (hitPoint < 0) 
		{
			hitPoint = 0;
		}

		UpdateHealthBar();
	}

	private void HealDamage(float heal)
	{
		hitPoint += heal;

		//placeholder
		if (hitPoint > maxHitPoint) 
		{
			hitPoint = maxHitPoint;
		}

		UpdateHealthBar();
	}
}
