using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour 
{
	public Image CurrentHealthBar;
	public Image CurrentShieldBar;
    public Image CurrentHealthBarPSCR;
    public Image CurrentShieldBarPSCR;

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
        CurrentHealthBarPSCR.transform.localScale = new Vector3(healthRatio, CurrentHealthBarPSCR.transform.localScale.y, CurrentHealthBarPSCR.transform.localScale.z);

        CurrentShieldBarPSCR.transform.localScale = new Vector3(shieldRatio, CurrentShieldBarPSCR.transform.localScale.y, CurrentShieldBarPSCR.transform.localScale.z);

        ratioText.text = ((healthRatio+shieldRatio) * 100).ToString("0") + '%';


	}


    private void Update() {
        UpdateHealthBar();
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

    public void addHeal(float value) {

        if (hitPoint + value > maxHitPoint) {
            hitPoint = maxHitPoint;
        } else {
            hitPoint += value; 
        }

    }


    public void addShield(float value) {
        if (hitShield + value > maxHitShield) {
            hitShield = maxHitShield;
        } else {
            hitShield += value;
        }
    }


}
