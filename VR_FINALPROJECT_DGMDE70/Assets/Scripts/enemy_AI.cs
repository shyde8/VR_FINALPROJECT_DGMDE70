using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_AI : MonoBehaviour {

	Transform tr_Player;
	float f_RotSpeed=3.0f,f_MoveSpeed = 6.0f;
	// Use this for initialization
	void Start () {
		tr_Player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		//look at player
		transform.rotation = Quaternion.Slerp(transform.rotation
			,Quaternion.LookRotation(tr_Player.position - transform.position), f_RotSpeed * Time.deltaTime);

		//move at player
		transform.position += transform.forward*f_MoveSpeed*Time.deltaTime;
	}
}
