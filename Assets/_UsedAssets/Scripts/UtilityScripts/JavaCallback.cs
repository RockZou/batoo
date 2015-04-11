using UnityEngine;
using System.Collections;

public class JavaCallback : MonoBehaviour {

	void onActivityResult(string theString){
		Debug.Log ("onActivityResult in Unity is Called: "+theString);

		///?code=h4MjiL7u785Ysp_Z0_9aYGrXwHmJEIP0hI5n1rBAbdMwi2p1M3zvISp96z_99ToG&state=88725247


		string[] result = theString.Split('=');
		string t_string = result [1];
		result = t_string.Split ('&');
		t_string = result [0];
		
		Debug.Log ("the Code is: "+t_string);
		PlayerPrefs.SetString ("CODE", t_string);
		GameObject APIObj = GameObject.Find ("APIRequests");
		APIObj.GetComponent<APIRequests> ().callGetToken ();

		GameObject APIButtonObj = GameObject.Find("APIButton");
		//api.GetComponent<APIRequests>().callGetToken ();
	}

}
