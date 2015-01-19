using UnityEngine;
using System.Collections;
using SocketIO;

public class WSS : MonoBehaviour {

	// Use this for initialization
	void OnStart () {
		GameObject go = GameObject.Find("SocketIO");
		SocketIOComponent socket = go.GetComponent<SocketIOComponent>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
