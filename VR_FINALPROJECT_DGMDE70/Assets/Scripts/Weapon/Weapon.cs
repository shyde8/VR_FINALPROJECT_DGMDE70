using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	private Animator anim;
	private AudioSource _AudioSource;

	public float range = 100f;
	public int bulletsPerMag = 30;
	public int bulletsLeft = 200;
	public int currentBullets;

	public enum ShootMode {Auto, Semi }
	public ShootMode shootingMode;

	public Text ammoText;
	public Transform shootPoint;
	public GameObject hitParticles;
	public GameObject bulletImpact;

	public ParticleSystem muzzleFlash;
	public AudioClip shootSound;

	public float fireRate = 0.1f;
	public float damage = 20f;

	float fireTimer;

	private bool isReloading;
	private bool isAiming;
	private bool shootInput;

	private Vector3 originalPosition;
	public Vector3 aimPosition;
	public float aodSpeed = 8f;
    

    
	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
		_AudioSource = GetComponent<AudioSource>();
		currentBullets = bulletsPerMag;

		originalPosition = transform.localPosition;

		UpdateAmmoText();
        

    }

	// Update is called once per frame
	void Update()
	{
		switch (shootingMode) 
		{
		case ShootMode.Auto:
			shootInput = Input.GetButton ("Fire1");
			break;
		case ShootMode.Semi:
			shootInput = Input.GetButtonDown ("Fire1");
			break;		
		}

		//shyde, changing to detect "PVR_LeftTrigger", 11/22
		if ((Input.GetAxis ("PVR_RightTrigger")>.05))
		{
			if (currentBullets > 0) {
				Fire ();


				Vector3 rayOrigin = transform.position;
				Vector3 rayTarget = transform.forward;

				RaycastHit targetObject;
				Physics.Raycast(rayOrigin, rayTarget, out targetObject, 1000);

				if (targetObject.collider != null) {
					Debug.Log ("1");
					if (targetObject.collider.CompareTag("Enemy")) {
						Debug.Log ("12");
						Destroy (targetObject.collider.gameObject);

					}


				}

			} else if (bulletsLeft > 0) {
				DoReload ();
			}
		}

		if (Input.GetKeyDown (KeyCode.R)) 
		{
			if(currentBullets < bulletsPerMag && bulletsLeft > 0)
				DoReload ();
		}
		if (fireTimer < fireRate)
			fireTimer += Time.deltaTime;

		AimDownSights();
	}

	void FixedUpdate()
	{
		AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo (0);

		isReloading = info.IsName ("Reload");
		anim.SetBool ("Aim", isAiming);

		//if (info.IsName ("Fire"))
		//anim.SetBool ("Fire", false);
	}

	private void AimDownSights()
	{
		//shyde, changing to detect "PVR_LeftTrigger", 11/22
		if ((Input.GetAxis ("PVR_LeftTrigger")>.1) && !isReloading) 
		{
			transform.localPosition = Vector3.Lerp (transform.localPosition, aimPosition, Time.deltaTime * aodSpeed);
			isAiming = true;
		} 
		else 
		{
			transform.localPosition = Vector3.Lerp (transform.localPosition, originalPosition, Time.deltaTime * aodSpeed);
			isAiming = false;
		}
	}

	private void Fire()
	{
		if (fireTimer < fireRate || currentBullets <= 0 || isReloading) return;

		RaycastHit hit;
		if (Physics.Raycast (shootPoint.position, shootPoint.transform.forward, out hit, range)) 
		{
			Debug.Log (hit.transform.name + " found!");

			GameObject hitParticleEffect = Instantiate (hitParticles, hit.point, Quaternion.FromToRotation (Vector3.up, hit.normal));
			//GameObject bulletHole = Instantiate (bulletImpact, hit.point, Quaternion.FromToRotation (Vector3.forward, hit.normal));

			Destroy (hitParticleEffect, 1f);
			//Destroy (bulletHole, 2f);

			if (hit.transform.GetComponent<HealthController>()) 
			{
				hit.transform.GetComponent<HealthController>().ApplyDamage(damage);
			}
		}

		anim.CrossFadeInFixedTime ("Fire", 0.01f);
		muzzleFlash.Play();
		PlayShootSound();
		currentBullets--;
		UpdateAmmoText();
		fireTimer = 0.0f; //Reset fire timer

	}

	public void Reload()
	{
		if (bulletsLeft <= 0)
			return;

		int bulletsToLoad = bulletsPerMag - currentBullets;
		int bulletsToDeduct = (bulletsLeft >= bulletsToLoad) ? bulletsToLoad : bulletsLeft;

		bulletsLeft -= bulletsToDeduct;
		currentBullets += bulletsToDeduct;
		UpdateAmmoText();
	}

	private void DoReload()
	{
		AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo (0);

		if (isReloading)
			return;
		anim.CrossFadeInFixedTime("Reload", 0.01f);
	}

	private void PlayShootSound()
	{
		_AudioSource.PlayOneShot (shootSound);
		//_AudioSource.clip = shootSound;
		//_AudioSource.Play();
	}

	private void UpdateAmmoText()
	{
		ammoText.text = currentBullets + "/" + bulletsLeft;
	}

    private int GetPlayerInput(string val) {
        if (IsPressed("PSCR_" + val) && IsPressed("PVR_" + val)) {
            return 1;
        } else if (!IsPressed("PVR_" + val) && IsPressed("PSCR_" + val)) {
            return 2;
        } else {
            return 0;
        }
    }

    private bool IsPressed(string val) {
        return Input.GetButtonDown(val);
    }

}