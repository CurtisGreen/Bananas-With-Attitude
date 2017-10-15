using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//player can pick up a hostage
public class Hostage : MonoBehaviour {

	bool hostageGet = true;
	Player playerScript;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name == "Player" && hostageGet == true) {
			print ("hostage rescued!");
			//make gameobject disappear once the player collides with it
			this.gameObject.GetComponent<Renderer> ().enabled = false;
			hostageGet = false;
			playerScript.hostageCount++;
		}
	}

	// Use this for initialization
	void Start () {
		playerScript = GameObject.Find ("Player").GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
