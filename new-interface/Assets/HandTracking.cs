using UnityEngine;
using System.Collections;
using Meta;

public class HandTracking : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Hand[] hands = Meta.Hands.GetHands;

		Hand left = Meta.Hands.left;
		Palm lp = left.palm;
		Vector3 position = lp.position;

		transform.position = position;
	}
}