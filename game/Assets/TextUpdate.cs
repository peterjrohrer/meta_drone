using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log (typeof(GameObject));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Rise(float y){
		GetComponent<Text> ().text = "Altitude - Rising";
		GetComponent<Text> ().color = Color.green;
	}
	public void Fall(float y){
		GetComponent<Text> ().text = "Altitude - Falling";
		GetComponent<Text> ().color = Color.red;
	}
	public void Err(){
	
		GetComponent<Text> ().text = "No altitude hand!";
		GetComponent<Text> ().color = Color.white;
	}
	public void Middle(){
		GetComponent<Text> ().text = "Middle";
		GetComponent<Text> ().color = new Color(0f, 0.545f, 0.545f);//blue
	}
}
