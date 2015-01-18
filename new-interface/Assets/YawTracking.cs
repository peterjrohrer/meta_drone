using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Meta;
using SocketIO;
//using TextUpdate;

public class YawTracking : MetaBehaviour {
	
	// Use this for initialization
	
	public Text t;
	void OnStart () {
		
		//GameObject.Find ("RiseFall").guiText.text = "AAA";
	}
	
	// Update is called once per frame
	void Update () {
		Hand[] hands = Meta.Hands.GetHands();
		
		//Debug.Log (hands + ":" + hands.Length);
		
		if (hands.Length > 0) {
			Hand right = Meta.Hands.right;
			//Debug.Log(right);
			if(right != null && right.isValid){
				Palm rp = right.palm;
				Vector3 position = rp.position;
				
				//Debug.Log(right.handOpenness);
				//position.y = 0;
				transform.position = position;
				
				//t.GetComponent<YawTextUpdate>().Set(position.x);
				if(position.x > 0.05){
					t.GetComponent<YawTextUpdate>().Right(position.x);
					gameObject.GetComponent<SocketIOComponent>().Emit ("right");
				}
				else if(position.x < -0.05){
					t.GetComponent<YawTextUpdate>().Left(position.x);
					gameObject.GetComponent<SocketIOComponent>().Emit ("left");
				}
				else
					t.GetComponent<YawTextUpdate>().Middle();
				
				//Debug.Log (angle * 180 / Mathf.PI);
				
				//gameObject.GetComponent<SocketIOComponent>()
				
			} else{//hand not on screen
				t.GetComponent<YawTextUpdate>().Err();
			}
			
		}
		
		hands = Meta.Hands.GetHands();
		if (hands.Length == 2 && Meta.Hands.left.isValid && Meta.Hands.right.isValid) {//all hands present and accounted for
			if(Meta.Hands.left.handOpenness > 30 && Meta.Hands.right.handOpenness > 30){//gotta kill it!
				gameObject.GetComponent<SocketIOComponent>().Emit ("kill");
			}
		}
		
	}
	
}
