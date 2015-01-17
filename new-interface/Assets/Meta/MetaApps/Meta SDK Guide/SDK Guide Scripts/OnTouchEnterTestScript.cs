/************************************************************************************
 *  Copyright © 2014 Meta Company. All Rights Reserved. Use of this software source *
 *  code and binaries requires agreement and compliance with the META Licensed 		*
 *  Application End User License Agreement in the accompanying META EULA.txt file, 	*
 *  which must be included as part of this software for any use. 					*
 ************************************************************************************/

using UnityEngine;
using System.Collections;

namespace Meta.Apps.SDKGuide
{

	public class OnTouchEnterTestScript : MetaBehaviour
	{
		public void OnTouchEnter()
		{
			renderer.material.color = Color.red;
//			Debug.Log("OnTouchEnter");
		}
		public void OnTouchHold()
		{
			renderer.material.color = Color.green;
		}
		public void OnTouchDwell()
		{
			renderer.material.color = Color.cyan;
		}
		public void OnTouchExit()
		{
			renderer.material.color = Color.blue;
		}
	}
}