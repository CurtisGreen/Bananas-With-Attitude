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
		spriteRenderer = GetComponent<SpriteRenderer> ();
		if (spriteRenderer.sprite == null) {
			spriteRenderer.sprite = right;
		}
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
		if(velX > 0.0f) {
			this.spriteRenderer.sprite = right;
		}
		if(velX < 0.0f) {
			this.spriteRenderer.sprite = left;
		}
		if(velY > 0.0f) {
			this.spriteRenderer.sprite = up;
		}
		if(velY < 0.0f) {
			this.spriteRenderer.sprite = down;
		}
	}

	void PlayerAnim() {
		animator = GetComponent<Animator> ();
		animator.SetFloat ("VelX", velX);
		animator.SetFloat ("VelY", velY);
	}
}
