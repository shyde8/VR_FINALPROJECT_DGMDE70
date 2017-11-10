using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class collectingblue : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public AudioSource coinSource;
	public AudioClip coinClip;

	public bool hasPlayedAudio;


	
	private void OnTriggerEnter(Collider other)
	{
		if(other.name == "player")
		{
			Destroy(gameObject);
			//gameObject.SetActive(false);
			//GetComponent<AudioSource>().Play();
		}

		if(other.name == "player" && hasPlayedAudio == false)
		{
			coinSource.PlayOneShot(coinClip);
			hasPlayedAudio = false;
		}
	}

	


}
