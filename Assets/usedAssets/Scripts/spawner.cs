using UnityEngine;
using System.Collections;
using SimpleJSON;


public class spawner : MonoBehaviour {


	public int spawnTreshold = 5;
	public int spawnRadius = 200;
	public GameObject dude;

	bool initial = true;

	int numberGrabbedAPI;
	float SpawnerPositionX, SpawnerPositionY, SpawnerPositionZ ;
	
	int spawnCount = 0;

	public string url = "http://api.open-notify.org/astros.json";
	
	IEnumerator SendRequest(){
		WWW request = new WWW(url);
		yield return request;
		if (request.error == null || request.error == ""){
			//Debug.Log(request.text);
			var N = JSON.Parse(request.text);
			numberGrabbedAPI = int.Parse((N["number"].Value));

		}else{
			Debug.Log("WWW error: " + request.error);
		}
	}


	// Use this for initialization
	void Start () {
		StartCoroutine(SendRequest());

		SpawnerPositionX = transform.position.x;
		SpawnerPositionY = transform.position.y;
		SpawnerPositionZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {

		if(numberGrabbedAPI != 0 && initial ){
			spawnTreshold = numberGrabbedAPI;
			initial = false;
		}


		if( numberGrabbedAPI != 0){
			if(spawnCount < spawnTreshold){
				Vector2 randomPosition = Random.insideUnitCircle;
				
				Instantiate(dude, 
				            (new Vector3( 	SpawnerPositionX  + randomPosition.x * spawnRadius, 
				             0f , 
				             SpawnerPositionZ  + randomPosition.y * spawnRadius )),
				            Quaternion.Euler(0f, Random.Range(0,359), 0f));

				Debug.Log("Instanciated");
				spawnCount++;
			}
		}

		if(Input.GetKey(KeyCode.Space)){
			Debug.Log("Pressed");
			spawnTreshold++;
		}

	}
}
