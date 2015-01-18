using UnityEngine;
using System.Collections;
using Meta;
using SocketIO;

public class Kill : MetaBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Hand[] hands = Meta.Hands.GetHands();
		if (hands.Length == 2 && Meta.Hands.left.isValid && Meta.Hands.right.isValid) {//all hands present and accounted for
			if(Meta.Hands.left.handOpenness < -10 && Meta.Hands.right.handOpenness < -10){//gotta kill it!
				gameObject.GetComponent<SocketIOComponent>().Emit ("kill");
			}
		}
	}
}
