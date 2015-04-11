using UnityEngine;
using System.Collections;

public class NPCRaycast : MonoBehaviour {


	public GameObject theOcean;
	public float speed = 0.5f;
	public float raycast_range = 1f;

	// Use this for initialization
	void Start () {
		Debug.Log ("Physics controller called");
		theOcean = GameObject.Find ("Ocean");
	}
	
	// Dude AI. Creates a ray from the body of the dude. Checks a short distance ( raycast range) to check for colission
	// If there is a colission set a random rotation
	void FixedUpdate () {

		Vector3 waterPositions = theOcean.GetComponent<Transform>().position;
		float waterLevel = waterPositions.y;

		Debug.Log (transform.position.y);

		GetComponent<Rigidbody>().AddForce(-transform.right * speed, ForceMode.VelocityChange );

		Ray ray = new Ray (transform.position, transform.forward);
		
		if ( transform.position.y<waterLevel ){
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			transform.Rotate(0f, Random.Range(0,359), 0f);
			return;
		}

		if (Physics.Raycast(ray, raycast_range ) ){
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			transform.Rotate(0f, Random.Range(0,359), 0f);
			return;
		}

	}
}
