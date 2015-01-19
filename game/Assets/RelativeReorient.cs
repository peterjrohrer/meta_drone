using UnityEngine;
using System.Collections;

public class RelativeReorient : MonoBehaviour {

	// Use this for initialization
	Camera c;
	void OnStart () {
		c = Camera.current;
		gameObject.renderer.material.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = getAligned ();
	}

	
	Vector3 getAligned(){

		return c.transform.forward;
		
	}
}
