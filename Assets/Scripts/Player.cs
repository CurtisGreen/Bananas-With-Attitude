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
	protected BoxCollider2D boxcollider;
	public int health = 3;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		boxcollider = GetComponent<BoxCollider2D> ();
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
			//hardcoding things is totally safe!
			this.boxcollider.size = new Vector2(0.62f,0.57f);
		}
		if(velX < 0.0f) {
			this.spriteRenderer.sprite = left;
			this.boxcollider.size = new Vector2(0.62f,0.57f);
		}
		if(velY > 0.0f) {
			this.spriteRenderer.sprite = up;
			this.boxcollider.size = new Vector2(0.22f,0.57f);
		}
		if(velY < 0.0f) {
			this.spriteRenderer.sprite = down;
			this.boxcollider.size = new Vector2(0.22f,0.57f);
		}
	}

	void PlayerAnim() {
		animator = GetComponent<Animator> ();
		animator.SetFloat ("VelX", velX);
		animator.SetFloat ("VelY", velY);
	}
}
