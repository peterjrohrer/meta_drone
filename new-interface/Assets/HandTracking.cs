using UnityEngine;
using System.Collections;
using Meta;
using SocketIO;

public class HandTracking : MetaBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Hand[] hands = Meta.Hands.GetHands();

		//Debug.Log (hands + ":" + hands.Length);

		if (hands.Length > 0) {
			Debug.Log (hands[0]);
			Hand right = Meta.Hands.right;
			//Debug.Log(right);
			if(right != null){
				Palm rp = right.palm;
				Vector3 position = rp.position;

				//Debug.Log(right.handOpenness);
				//position.y = 0;
				if(right.handOpenness < -10)
					gameObject.GetComponent<SocketIOComponent>().Emit("land");
				transform.position = position;

				float angle = Mathf.Atan2(position.z, position.x);
				
				if(position.y < 0){
					gameObject.renderer.material.color = Color.red;
					gameObject.GetComponent<SocketIOComponent>().Emit("fall");
				}
				else{
					gameObject.renderer.material.color = Color.green;
					gameObject.GetComponent<SocketIOComponent>().Emit("rise");
				}
				//Debug.Log (angle * 180 / Mathf.PI);
				if(position.x < 0)
					angle *= -1;

				//gameObject.GetComponent<SocketIOComponent>()

			}
		
		}

	}

}