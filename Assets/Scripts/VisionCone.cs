using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCone : MonoBehaviour {

    public Transform sightStart, sightEnd1, sightEnd2;

    public bool spotted = false;
    private float playerSpeed;
    Guard playerScript;

    /*
     * Initializing. Set the component from Guard.cs to playerScript
     * and set the speed of the player to playerSpeed from playerScript
         */
    private void Start() 
    {
        playerScript = this.GetComponent<Guard>();
        playerSpeed = playerScript.playerSpeed;
    }
    // Update is called once per frame
    void Update () {
        Raycasting();
        Behaviors();
        playerSpeed = playerScript.playerSpeed;
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
            print("sees player");
            // maybe show an exclamation mark?
        }
        // 
        
    }
}

