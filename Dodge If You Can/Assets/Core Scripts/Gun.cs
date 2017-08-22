﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Gun : MonoBehaviour
{
	public Rigidbody2D rocket;				// Prefab of the rocket.
	public float speed = 20f;				// The speed the rocket will fire at.


	private Player playerCtrl;		// Reference to the PlayerControl script.
//	private Animator anim;					// Reference to the Animator component.


	void Awake()
	{
		// Setting up the references.
//		anim = transform.root.gameObject.GetComponent<Animator>();
		playerCtrl = transform.root.GetComponent<Player>();
	}


	void Update ()
	{
		// If the fire button is pressed...
		if(CrossPlatformInputManager.GetButtonDown("Fire1") && GameObject.FindGameObjectWithTag ("Game Menager").GetComponent<GameManager>().paused == false)
		{
			// ... set the animator Shoot trigger parameter and play the audioclip.
//			anim.SetTrigger("Shoot");
			GetComponent<AudioSource>().Play();

			// If the player is facing right...
			if(playerCtrl.facingRight)
			{
				// ... instantiate the rocket facing right and set it's velocity to the right. 
				Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
				if(bulletInstance != null)
					bulletInstance.velocity = new Vector2(speed, 0);
			}
			else
			{
				// Otherwise instantiate the rocket facing left and set it's velocity to the left.
				Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;
				if(bulletInstance != null)
					bulletInstance.velocity = new Vector2(-speed, 0);
			}
		}
	}
}
