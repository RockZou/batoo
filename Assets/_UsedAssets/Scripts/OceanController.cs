using UnityEngine;
using System.Collections;

public class OceanController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void changeSeaLevel(float targetSeaLevel)
	{
		//float currentSeaLevel = transform.position.y;
		//transform.position.y = Mathf.Lerp (currentSeaLevel, targetSeaLevel, Time.time);

		Vector3 t_position = transform.position;
		t_position.y = targetSeaLevel;
		transform.position = t_position;
	}
}
