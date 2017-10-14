using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//player can pick up a hostage
public class Hostage : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		
		if (other.gameObject.name == "Player") {
			print ("hostage rescued!");
			//make gameobject disappear once the player collides with is
			this.gameObject.GetComponent<Renderer> ().enabled = false;
		}

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
