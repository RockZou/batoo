using UnityEngine;
using System.Collections;

public class OceanController : MonoBehaviour {

	Vector3 currentSeaLevel;
	Vector3 targetSeaLevel;

	// Use this for initialization
	void Start () {
		targetSeaLevel = transform.position;
		targetSeaLevel.y = 170;
	}
	
	// Update is called once per frame
	void Update () {
		seaLevelUpdate ();
	}

	public void changeSeaLevel(float targetLevel)
	{
		targetSeaLevel.y = targetLevel;
	}

	public void seaLevelUpdate()
	{
		transform.position = Vector3.Lerp (transform.position, targetSeaLevel, Time.deltaTime);
	}
}
