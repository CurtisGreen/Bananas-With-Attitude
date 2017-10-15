using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisionCone : MonoBehaviour {

    public Transform sightStart, sightEnd1, sightEnd2;

    public bool spotted = false;
    private float playerSpeed;
    Guard guardScript;
	Player playerScript;
	Text spottedText;
	int spottedTimer = 10;
    public float time = 1;
    public Vector2 position;

    /*
     * Initializing. Set the component from Guard.cs to playerScript
     * and set the speed of the player to playerSpeed from playerScript
         */
    private void Start() 
    {
        guardScript = this.GetComponent<Guard>();
		playerSpeed = guardScript.playerSpeed;
		playerScript = GameObject.Find ("Player").GetComponent<Player> ();
		spottedText = GameObject.Find ("Spotted Message").GetComponent<Text> ();
		spottedText.text = ("");
        position = playerScript.transform.position;
    }
    // Update is called once per frame
    void Update () {
        Raycasting();
        Behaviors();
        playerSpeed = guardScript.playerSpeed;
        //MessageTimer ();
 
    }

    /*
     * if playerSpeed is greater than 0 then draw the sight lines from sightEnd1
     * else: draw a sightline  from sightEnd2 (IDK where that comes from)
         */
    void Raycasting()
    {
        if (playerSpeed > 0)
        {
            Debug.DrawLine(sightStart.position, sightEnd1.position, Color.green);
            spotted = Physics2D.Linecast(sightStart.position, sightEnd1.position, 1 << LayerMask.NameToLayer("Player"));
        }
        else
        {
            Debug.DrawLine(sightStart.position, sightEnd2.position, Color.green);
            spotted = Physics2D.Linecast(sightStart.position, sightEnd2.position, 1 << LayerMask.NameToLayer("Player"));
        }
    }
    
    void Behaviors()
    {
        if (spotted){
            //print("sees player");
            // maybe show an exclamation mark?
			//reset player to beginning location, lose 1 HP
			//playerScript.transform.position = new Vector3(-5,0,0);
			playerScript.lives--;
            if (playerScript.lives == 0)
                playerScript.transform.position = position;
            {
            }
			spottedText.text = ("You got Spotted");
			//Destroy(spottedText, time);
           
        }

    }


}

