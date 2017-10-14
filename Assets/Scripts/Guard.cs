using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : Character {

	public Rigidbody rigidBody;
	float moveX;
	float moveY;
	float velX;
	float velY;
	public float playerSpeed = 1;
	Animator animator;
    public Transform currentWaypoint, point1, point2;
    //public GameObject targetA, targetB;
    public float currentPosition = 0.0f;

	// Use this for initialization
	void Start () {
        currentWaypoint = point2;
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
        
        var moveTo = currentWaypoint.transform.position.y - transform.position.y;
        if (Mathf.Abs(moveTo) <= 0.1f)
        {
            // At waypoint so stop moving
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            playerSpeed = -playerSpeed;
            if (currentWaypoint == point2)
            {
                currentWaypoint = point1;
            }
            else
            {
                currentWaypoint = point2;
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Transform>().localScale.y * playerSpeed);
        }
    }
}
//GetComponent<Transform>().localScale.y * playerSpeed
//GetComponent<Rigidbody2D>().velocity.y
