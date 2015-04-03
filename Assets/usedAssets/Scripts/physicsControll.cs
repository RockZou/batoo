﻿using UnityEngine;
using System.Collections;

public class physicsControll : MonoBehaviour {


    Rigidbody rbody;
	Transform position;
	public float speed = 5f;
	public float smoothTime = 2f;
	public float stopSpeed = 100f;
	public float treshold = 2f;
	public float stopTreshold = 0.5f;

	float boost = 1f;

	Vector3 impactPoint;
	Vector3 currentPosition;
	Vector3 moveDirection;

	Vector3 zeroVelocity = Vector3.zero;

	float initialDistance;
	float slowTreshold;

	bool distanceFlag = true;

	// Use this for initialization
	void Start () {

	}
	
	// FixedUpdate is called one a fixed interval / every physics frame
    // Use this when you are doing with physics
	void Update(){
	

	}
	void FixedUpdate () {
		Ray cursorRay = Camera.main.ScreenPointToRay( Input.mousePosition);
		RaycastHit cursorRayInfo = new RaycastHit();
		
		if(Physics.Raycast(cursorRay, out cursorRayInfo, 100f)){
			
			if (Input.GetMouseButtonDown(0) ){
				impactPoint = cursorRayInfo.point;
				currentPosition = transform.position;
				distanceFlag = true;
			}
		}
		
		moveDirection = impactPoint - currentPosition;
		
		if (distanceFlag){
			rigidbody.velocity = moveDirection.normalized * 5f;
			initialDistance = Vector3.Distance(transform.position, impactPoint);
			distanceFlag = false;
		}

		float distance = Vector3.Distance(transform.position, impactPoint);
		
		slowTreshold = (initialDistance / treshold);
		if ( distance - 1f > slowTreshold){
			rigidbody.AddForce( moveDirection.normalized * speed * boost 
			                   , ForceMode.VelocityChange);
		}


		// Ask why overshooting.
		if( distance < slowTreshold && distance > stopTreshold){
			transform.position = Vector3.SmoothDamp(transform.position, 
			                                        impactPoint, 
			                                        ref zeroVelocity, 
			                                        smoothTime);
		
		} else if (distance < stopTreshold){
			rigidbody.velocity = Vector3.zero;
		}
	}
}
