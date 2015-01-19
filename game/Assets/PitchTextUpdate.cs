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

	public void Middle(){
		GetComponent<Text> ().text = "Middle";
		GetComponent<Text> ().color = new Color(0f, 0.545f, 0.545f);//blue
	}
	
	public void Forwards(float y){
		GetComponent<Text> ().text = "Pitch - Forwards";
		GetComponent<Text> ().color = Color.cyan;
	}
	public void Back(float y){
		GetComponent<Text> ().text = "Pitch - Backwards";
		GetComponent<Text> ().color = Color.yellow;
	}
	public void Err(){
		
		GetComponent<Text> ().text = "No pitch hand!";
		GetComponent<Text> ().color = Color.white;
		
	}
}
