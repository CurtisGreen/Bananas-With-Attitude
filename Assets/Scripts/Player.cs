using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	public Rigidbody rigidBody;
	float moveX;
	float moveY;
	float velX;
	float velY;
	public float playerSpeed = 10;
	Animator animator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMove ();
		PlayerAnim ();
	}

	void PlayerMove() {
		this.moveX = Input.GetAxis ("Horizontal");
		this.moveY = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveX, moveY);
		rigidBody.velocity = movement.normalized * playerSpeed;
		velX = rigidBody.velocity.x;
		velY = rigidBody.velocity.y;
	}

	void PlayerAnim() {
		animator = GetComponent<Animator> ();
		animator.SetFloat ("VelX", velX);
		animator.SetFloat ("VelY", velY);
	}
}
