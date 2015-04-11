using UnityEngine;
using System.Collections;

public class ButtonEvent : MonoBehaviour {

	APIRequests APIObj;
	JSONDataObject jsonDataObj;
	public void Start(){
		APIObj = GameObject.Find ("APIRequests").GetComponent<APIRequests> ();
		jsonDataObj = GameObject.Find ("JSONDataObject").GetComponent<JSONDataObject> ();
	}

	public void doRequestMovesAuthInApp()
	{
		Debug.Log("Button is Clicked!");

		//Bridge.ShowCamera (12345);
		Bridge.doRequestMovesAuthInApp ();
	}

	public void getMovesAPIData(){
		Debug.Log ("getMovesAPIData called");
		APIObj.callGetData ();
	}

	public void doSomethingWithData(){
		jsonDataObj.doSomethingWithData ();
	}
}
