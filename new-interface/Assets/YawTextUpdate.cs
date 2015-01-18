using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class YawTextUpdate : MonoBehaviour {
	
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
	public void Left(float x){
		GetComponent<Text> ().text = "Yaw - CCW";
		GetComponent<Text> ().color = new Color(1f, 0.549f, 0f);//orange
	}
	public void Right(float x){
		GetComponent<Text> ().text = "Yaw - CW";
		GetComponent<Text> ().color = new Color (0.541f, 0.1686f, 0.8862f);
	}
	public void Err(){
		
		GetComponent<Text> ().text = "No yaw hand!";
		GetComponent<Text> ().color = Color.white;
		
	}
}
