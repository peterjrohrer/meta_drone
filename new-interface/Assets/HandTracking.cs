using UnityEngine;
using System.Collections;
using Meta;

public class HandTracking : MetaBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Hand[] hands = Meta.Hands.GetHands();

		Debug.Log (hands + ":" + hands.Length);

		if (hands.Length > 0) {
			Debug.Log (hands[0]);
			Hand right = Meta.Hands.right;
			//Debug.Log(right);
			if(right != null){
				Palm rp = right.palm;
				Vector3 position = rp.position;
				Debug.Log(right.handOpenness);
				position.y = 0;
				transform.position = position;


			}
		
		}

	}
}