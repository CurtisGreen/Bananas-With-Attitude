using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : Character {

	public Rigidbody rigidBody;
	float moveX;
	float moveY;
	float velX;
	float velY;
	public float playerSpeed = 10;
    public float ToMove;
	Animator animator;
    public Transform point1, point2;
    int point = 1;
    public GameObject targetA, targetB;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//PlayerMove ();
		//PlayerAnim ();
        CheckPos();
	}

	void PlayerMove() {
		this.moveX = Input.GetAxis ("Horizontal");
		this.moveY = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveX, moveY);
		rigidBody.velocity = movement * playerSpeed;
		velX = rigidBody.velocity.x;
		velY = rigidBody.velocity.y;
	}

	void PlayerAnim() {
		animator = GetComponent<Animator> ();
		animator.SetFloat ("VelX", velX);
		animator.SetFloat ("VelY", velY);
	}

    void CheckPos()
    {
        if (Vector2.Distance(point1.position, transform.position) > 1)
        {
            transform.position += transform.up * ToMove * -1;
        }
    }
}
