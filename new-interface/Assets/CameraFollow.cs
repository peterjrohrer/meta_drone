using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	// Use this for initialization
	void OnStart () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward, Camera.main.transform.up);
		//transform.position = Camera.main.ScreenToWorldPoint (Vector3 (Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
		transform.position = Camera.main.transform.forward;

	}
}
