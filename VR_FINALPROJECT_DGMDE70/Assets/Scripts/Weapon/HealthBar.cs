using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour 
{
	public Image CurrentHealthBar;
	public Image CurrentShieldBar;
	public Text ratioText;

	private float hitPoint = 100;
	private float maxHitPoint = 100;
	private float hitShield = 40;
	private float maxHitShield = 100;

	private void Start()
	{
		//Calling UpdateHealthBar() to start
		UpdateHealthBar();
	}

	private void UpdateHealthBar()
	{
		//gives us value between 0 and 1
		float healthRatio = hitPoint / maxHitPoint;
		float shieldRatio = hitShield / maxHitShield;

		//scale CurrentHealthBar based on ratio
		CurrentHealthBar.rectTransform.localScale = new Vector3 (healthRatio, 1, 1);
		CurrentShieldBar.rectTransform.localScale = new Vector3 (shieldRatio, 1, 1);

		ratioText.text = ((healthRatio+shieldRatio) * 100).ToString("0") + '%';


	}

	private void TakeDamage(float damage)
	{
		if (hitShield > 0) 
		{
			hitShield -= damage;
		} 
		else 
		{
			hitPoint -= damage;
		}

		//call endGame() function within GameOver script, if health hits 0
		if (hitPoint <= 0) 
		{
			hitPoint = 0;
			FindObjectOfType<GameOver>().endGame ();
		}

		UpdateHealthBar();
	}

	private void HealDamage(float heal)
	{
		if (hitPoint < maxHitPoint) 
		{
			hitPoint += heal;
		} 
		else
		{
			hitShield += heal;
		}

		//placeholder to prevent scaling issues if we hit superceded maxHitShield
		if (hitShield > maxHitShield) 
		{
			hitShield = maxHitShield;
		}

		UpdateHealthBar();
	}
}
