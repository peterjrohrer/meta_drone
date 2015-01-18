using UnityEngine;
using System.Collections;
using Meta;
using SocketIO;
using UnityEngine.UI;

public class Kill : MetaBehaviour {

	// Use this for initialization
	public Text t;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Hand[] hands = Meta.Hands.GetHands();
		if (hands.Length == 2 && Meta.Hands.left.isValid && Meta.Hands.right.isValid) {//all hands present and accounted for
			if(Meta.Hands.left.handOpenness > 31 && Meta.Hands.right.handOpenness > 35){//gotta kill it!
				//gameObject.GetComponent<SocketIOComponent>().Emit ("kill");
				t.GetComponent<Text>().color = Color.red;
			}
			t.GetComponent<Text>().text = (Mathf.Round(Meta.Hands.left.handOpenness * 10) / 10.0) + ":" + (Mathf.Round(Meta.Hands.right.handOpenness * 10) / 10.0);
		}
	}
}
