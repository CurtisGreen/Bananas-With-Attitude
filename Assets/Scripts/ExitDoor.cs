using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour {

	Player playerScript;


	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name == "Player" && playerScript.hostageCount == 4) {
			// transition to victory screen
		} 
		else {
			// display message that the player has hostages left
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
