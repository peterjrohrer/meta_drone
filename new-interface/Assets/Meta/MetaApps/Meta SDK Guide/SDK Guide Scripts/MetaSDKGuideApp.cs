/************************************************************************************
 *  Copyright © 2014 Meta Company. All Rights Reserved. Use of this software source *
 *  code and binaries requires agreement and compliance with the META Licensed 		*
 *  Application End User License Agreement in the accompanying META EULA.txt file, 	*
 *  which must be included as part of this software for any use. 					*
 ************************************************************************************/

using System.Collections.Specialized;
using UnityEngine;
using System.Collections;

namespace Meta.Apps.SDKGuide
{
	/// <summary>
	/// MetaSDKGuide namespace demonstrates the fact that every app should have its own namespace.
	/// </summary>
	/// <remarks>
	/// Make sure to put all the scripts in your app into a namespace named after the app.
	/// </remarks>

		/// <summary>
		/// Meta SDK Guide App is an example app featuring example implementations of the SDK's features.
		/// </summary>
		/// <remarks>This is the root app controller script. Make a script named after your app and attach it to your app's root object alongside the MetaAppObject component. 
		/// * Put app-wide logic in it and handler methods for MetaAppObject events like OnHide, OnShow and OnQuit.
		/// * Enclose code in organizational regions like Member variables, Member methods, MonoBehaviour methods, MetaBehaviour methods.
		/// <para>
		/// Includes example scripts called OnTouchEnterTestScript, OnGrabTestScript, OnSwipeTestScript.
		/// </para>
		/// </remarks>
		public class MetaSDKGuideApp : MetaBehaviour
		{
			#region Member variables

			/// <summary>
			/// How many guide sections has the user explored?
			/// </summary>
			public int sectionsExplored = 0;
			/// <summary>
			/// How many guide sections could be explored?
			/// </summary>
			public int maxSectionsExplored = 10;
			#endregion

			#region Member methods
			public void SectionExplored()
			{
				sectionsExplored++;
			}

			public void Quit()
			{
				MetaSpace.Shutdown();
			}

			public void LoadWelcome()
			{
				MetaSpace.LoadScene("MetaWelcomeScene");
			}

			#endregion Member methods

			#region MonoBehaviour methods
			// Use this for initialization
			void Start()
			{

			}

			// Update is called once per frame
			void Update()
			{

			}
			#endregion MonoBehaviour methods

			#region MetaBehaviour methods
			public void OnHide()
			{

			}
			#endregion MetaBehaviour methods



		}

}