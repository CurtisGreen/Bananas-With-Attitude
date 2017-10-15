using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class Player : Character
{

    public Rigidbody2D rigidBody;
    float moveX;
    float moveY;
    float velX;
    float velY;
    public float playerSpeed = 4;
    Animator animator;
    protected BoxCollider2D boxcollider;
    public int lives = 3;
    public bool victory = false;

	public Text spottedText;
	public float spottedTimer = 3.0f;
	public bool spottedForTimer = false;

	//keep count of number of bananas rescued
	public int hostageCount = 0;


    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxcollider = GetComponent<BoxCollider2D>();
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = right;
        }
		spottedText = GameObject.Find ("Spotted Message").GetComponent<Text> ();
		spottedText.text = ("");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerAnim();
		if (lives == 0) {
			SceneManager.LoadScene("Defeat Screen");
			// transition to defeat scene
		}
		if (victory)
		{
			SceneManager.LoadScene("Victory Screen");
		}
		if (spottedForTimer) {
			spottedTimer -= Time.deltaTime;
			if (spottedTimer <= 0.0f) {
				spottedText.text = ("");
				spottedForTimer = false;
				spottedTimer = 3.0f;
			}
		}
    }

    void PlayerMove()
    {
        this.moveX = Input.GetAxis("Horizontal");
        this.moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX, moveY);
        rigidBody.velocity = movement * playerSpeed;
        velX = rigidBody.velocity.x;
        velY = rigidBody.velocity.y;
        checkDirection();
    }

    void checkDirection(){
        if (velX > 0.0f)
        {
            this.spriteRenderer.sprite = right;
            //hardcoding things is totally safe!
            this.boxcollider.size = new Vector2(0.6f, 0.5f);
        }
        if (velX < 0.0f)
        {
            this.spriteRenderer.sprite = left;
            this.boxcollider.size = new Vector2(0.6f, 0.55f);
        }
        if (velY > 0.0f)
        {
            this.spriteRenderer.sprite = up;
            this.boxcollider.size = new Vector2(0.20f, 0.5f);
        }
        if (velY < 0.0f)
        {
            this.spriteRenderer.sprite = down;
            this.boxcollider.size = new Vector2(0.20f, 0.5f);
        }
    }

    void PlayerAnim()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("VelX", velX);
        animator.SetFloat("VelY", velY);
    }
}
