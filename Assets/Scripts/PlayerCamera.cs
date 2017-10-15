using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

	public Transform target;
	public float smoothTime = 0.3f;
	private Vector3 velocity = Vector3.zero;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {
		if (target) {
			Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, -10));
			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
		}
	}



}
