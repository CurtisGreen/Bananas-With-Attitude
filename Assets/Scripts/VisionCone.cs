using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCone : MonoBehaviour {

    public Transform sightStart, sightEnd1, sightEnd2;

    public bool spotted = false;
    private float playerSpeed;
    Guard playerScript;

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
        }

        
    }
}

