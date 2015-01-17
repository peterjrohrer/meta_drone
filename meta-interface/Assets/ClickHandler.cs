using UnityEngine;
using System.Collections;

public class ClickHandler : MonoBehaviour {

	void OnEnable(){
		Debug.Log ("Loaded");
		//gameObject.renderer.material.color = Color.red;
	}

	void OnMouseDown(){
		Debug.Log("Mouse down");
	}

}
