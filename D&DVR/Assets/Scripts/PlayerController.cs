﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour 
{

	public float moveForce = 5, boostMultipler = 2;
	Rigidbody myPlayer;

	// Use this for initialization
	void Start () 
	{
		myPlayer = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 moveVec = new Vector3 (CrossPlatformInputManager.GetAxis("Horizontal"),0, CrossPlatformInputManager.GetAxis("Vertical")) * moveForce;
		bool isBoosting = CrossPlatformInputManager.GetButton ("Boost");

		Vector3 lookVec = new Vector3 (CrossPlatformInputManager.GetAxis("Horizontal2"), CrossPlatformInputManager.GetAxis("Vertical2"), 4000);

		//This is needed so that the rotation does not snap back to the original if they are not both zero dont snapback
		if (lookVec.x != 0 && lookVec.y != 0) {
			transform.rotation = Quaternion.LookRotation (lookVec, Vector3.back);
		}

		Debug.Log (isBoosting ? boostMultipler : 1);
		//a single line if else statment , is the player boosting? if its true its use multiplier if false use 1
		myPlayer.AddForce (moveVec * (isBoosting ? boostMultipler : 1));
	}
}
