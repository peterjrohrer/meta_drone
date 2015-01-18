using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Meta;
using SocketIO;
//using TextUpdate;

public class HandTracking : MetaBehaviour {

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

				float angle = Mathf.Atan2(position.z, position.x);
				
				if(position.y < 0){
					t.GetComponent<TextUpdate>().Fall(position.y);
					gameObject.GetComponent<SocketIOComponent>().Emit ("fall");

					//t.Fall();
					//GameObject.Find ("MGUI.Canvas/MGUI.Text").guiText.text = "JJJ";
					//GameObject.Find ("MGUI.Canvas/MGUI.Text").guiText.GetComponent<TextUpdate>().Fall();
				}
				else{
					t.GetComponent<TextUpdate>().Rise(position.y);
					gameObject.GetComponent<SocketIOComponent>().Emit ("rise");
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

		hands = Meta.Hands.GetHands();
		if (hands.Length == 2 && Meta.Hands.left.isValid && Meta.Hands.right.isValid) {//all hands present and accounted for
			if(Meta.Hands.left.handOpenness > 30 && Meta.Hands.right.handOpenness > 30){//gotta kill it!
				gameObject.GetComponent<SocketIOComponent>().Emit ("kill");
			}
		}
		
	}
	
}