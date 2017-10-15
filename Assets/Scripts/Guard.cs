using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : Character
{

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
	public bool vert;
    protected BoxCollider2D boxcollider;
    public float moveTo = 0;


    // Use this for initialization
    void Start()
    {
        currentWaypoint = point2;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null)
        {
			if (vert) {
				spriteRenderer.sprite = up;
			} 
			else {
				spriteRenderer.sprite = right;	
			}
        }

    }

    // Update is called once per frame
    void Update()
    {
        //PlayerMove ();
        //PlayerAnim ();
        PaceBackForth();
    }
    /*
     * Move the player via horiazontal and vertical inputs. update the velocity from these inputs
         */
    void PlayerMove()
    {
        this.moveX = Input.GetAxis("Horizontal");
        this.moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX, moveY);
        rigidBody.velocity = movement * playerSpeed;
        velX = rigidBody.velocity.x;
        velY = rigidBody.velocity.y;
    }
    /*
     * animate a player's movement. Set velocity by X and Y
         */
    void PlayerAnim()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("VelX", velX);
        animator.SetFloat("VelY", velY);
    }

    /*
     * called on update:
     *
     * paces back and forth from current position to currentWaypoint
         */
    void PaceBackForth()
    {
        if (vert)
            moveTo = currentWaypoint.transform.position.y - transform.position.y;
        else
            moveTo = currentWaypoint.transform.position.x - transform.position.x;

        if (Mathf.Abs(moveTo) <= 0.1f)
        {
            // At waypoint so stop moving
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            playerSpeed = -playerSpeed;
            if (currentWaypoint == point2)
            {
                currentWaypoint = point1;
                //Debug.Log("down");
                if (vert)
                    this.spriteRenderer.sprite = down;
                else
                    this.spriteRenderer.sprite = left;
            }
            else
            {
                currentWaypoint = point2;
                //Debug.Log("up");
                if (vert)
                    this.spriteRenderer.sprite = up;
                else
                    this.spriteRenderer.sprite = right;
            }
        }
        else
        {
            if (vert)
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Transform>().localScale.y * playerSpeed);
            else
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Transform>().localScale.x * playerSpeed, 0);
        }
    }
}
//GetComponent<Transform>().localScale.y * playerSpeed
//GetComponent<Rigidbody2D>().velocity.y
