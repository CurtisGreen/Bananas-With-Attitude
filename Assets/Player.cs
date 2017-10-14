using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Rigidbody rigidBody;
	float moveX;
	float moveY;
	public float playerSpeed = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMove ();
	}

	void PlayerMove() {
		this.moveX = Input.GetAxis ("Horizontal");
		this.moveY = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveX, moveY);
		//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
		rigidBody.velocity = movement * playerSpeed;	
	}
}
