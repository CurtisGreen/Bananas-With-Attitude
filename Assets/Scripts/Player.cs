using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	public Rigidbody2D rigidBody;
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
		rigidBody.velocity = movement * playerSpeed;
		velX = rigidBody.velocity.x;
		velY = rigidBody.velocity.y;

		checkDirection ();
	}

	void checkDirection() {
		if (this.velX > 0.0f) {
			this.spriteRenderer.sprite = this.right;
		}
		if (this.velX < 0.0f) {
			this.spriteRenderer.sprite = this.left;
		}
		if (this.velY > 0.0f) {
			this.spriteRenderer.sprite = this.up;
		}
		if (this.velY < 0.0f) {
			this.spriteRenderer.sprite = this.down;
		}
	}

	void PlayerAnim() {
		animator = GetComponent<Animator> ();
		animator.SetFloat ("VelX", velX);
		animator.SetFloat ("VelY", velY);
	}


}
