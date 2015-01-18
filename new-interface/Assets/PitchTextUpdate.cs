using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PitchTextUpdate : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		Debug.Log (typeof(GameObject));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Forwards(float y){
		GetComponent<Text> ().text = "Pitch - Forwards: " + y;
		GetComponent<Text> ().color = Color.green;
	}
	public void Back(float y){
		GetComponent<Text> ().text = "Pitch - Backwards: " + y;
		GetComponent<Text> ().color = Color.red;
	}
	public void Err(){
		
		GetComponent<Text> ().text = "Pitch hand not on screen!";
		GetComponent<Text> ().color = Color.white;
		
	}
}
