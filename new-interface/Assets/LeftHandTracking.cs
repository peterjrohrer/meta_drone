using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Meta;
using SocketIO;
//using TextUpdate;

public class LeftHandTracking : MetaBehaviour {
	
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
			Hand left = Meta.Hands.left;
			//Debug.Log(right);
			if(left != null && left.isValid){
				Palm lp = left.palm;
				Vector3 position = lp.position;
				
				//Debug.Log(right.handOpenness);
				//position.y = 0;

				transform.position = position;
				
				float angle = Mathf.Atan2(position.z, position.x);
				
				if(position.y < 0){
					t.GetComponent<PitchTextUpdate>().Back(position.y);
					gameObject.GetComponent<SocketIOComponent>().Emit ("backwards");
					
					//t.Fall();
					//GameObject.Find ("MGUI.Canvas/MGUI.Text").guiText.text = "JJJ";
					//GameObject.Find ("MGUI.Canvas/MGUI.Text").guiText.GetComponent<TextUpdate>().Fall();
				}
				else{
					t.GetComponent<PitchTextUpdate>().Forwards(position.y);
					gameObject.GetComponent<SocketIOComponent>().Emit ("forwards");
					//t.Rise();
				}
				//Debug.Log (angle * 180 / Mathf.PI);
				if(position.x < 0)
					angle *= -1;
				
				//gameObject.GetComponent<SocketIOComponent>()
				
			} else{//hand not on screen
				t.GetComponent<TextUpdate>().Err();
			}
			
		}
		
	}
	
}