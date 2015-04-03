using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class cameramover : MonoBehaviour {


	public float speed = 100f;
	// Use this for initialization
	void Start () {
	
	}

	Vector3 arc1 = new Vector3(383.71f, -3.0f, 345.0f);
	Vector3 arc2 = new Vector3(630.41f, 22.0f, 1224.0f);
	Vector3 arc3 = new Vector3(1519.7f, -1.60f, 1213.0f);
	Vector3 arc4 = new Vector3(1699.61f, -3.0f, 541.0f);
	Vector3 arc5 = new Vector3(1416.71f, -3.0f, 192.0f);
	Vector3 house = new Vector3(1528.91f, 10.0f, 1548.0f);

	public Text Text;

	// Update is called once per frame
	void Update () {
		float boost = 1.5f;
		if (Input.GetKey (KeyCode.LeftShift)){
			boost = 3.0f;
		} else {
			boost = 1.5f;
		}


		if ( Input.GetKey ( KeyCode.A ) ) 	{ // Time.deltaTime is the fraction of a second in between a frame
			// a value that gets bigger with low FPS, smaller with high FPS
			transform.position -= Vector3.right * Time.deltaTime * speed * boost ;
		}

		if ( Input.GetKey ( KeyCode.D ) ) { // Time.deltaTime is the fraction of a second in between a frame
			// a value that gets bigger with low FPS, smaller with high FPS
			transform.position += Vector3.right * Time.deltaTime * speed * boost ;
		}

		if ( Input.GetKey ( KeyCode.W ) ) { // Time.deltaTime is the fraction of a second in between a frame
			// a value that gets bigger with low FPS, smaller with high FPS
			transform.position += Vector3.forward * Time.deltaTime * speed * boost ;
		}

		if ( Input.GetKey ( KeyCode.S ) ) { // Time.deltaTime is the fraction of a second in between a frame
			// a value that gets bigger with low FPS, smaller with high FPS
			transform.position -= Vector3.forward * Time.deltaTime * speed * boost;
		}
	}
}