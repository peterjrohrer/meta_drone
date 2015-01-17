/************************************************************************************
 *  Copyright © 2014 Meta Company. All Rights Reserved. Use of this software source *
 *  code and binaries requires agreement and compliance with the META Licensed 		*
 *  Application End User License Agreement in the accompanying META EULA.txt file, 	*
 *  which must be included as part of this software for any use. 					*
 ************************************************************************************/

using System;
//using UnityEditor;
using UnityEngine;
//using System;
using System.Text;
using System.Collections.Generic;
using System.IO; 
using System.Diagnostics;

namespace Meta.Apps.Welcome
{
	/// <summary>
	/// MetaWelcome is an app that greets new Meta SDK users. It supports mouse and keyboard to instruct the user on how to set up the Meta hardware before launching Meta demo apps.
	/// </summary>
	public class MetaWelcome : MonoBehaviour
	{
		
		#region variables
		
		private string unityPath = "C:\\Program Files (x86)\\Unity\\Editor\\Unity.exe"; // on 64 bit Windows
		private string tutorialPackagePath = "C:\\Program Files (x86)\\Meta\\MetaSDK\\Meta.unitypackage";
		private string createProjectPath = "C:\\Meta\\";
		
		public bool unityInstalled = false;
		
		//public GameObject newProjectButton;
		//public GameObject installUnityButton;
		
		public enum State
		{
			Welcome,
			Quickstart,
			New,
			Demos,
			Documentation,
			Update
		}
		
		public State state = State.Welcome;
		
		public GameObject imuCheckPanel;
		public GameObject welcomePanel;
		public GameObject demoPanel;
		//public GameObject newPanel;
		//public GameObject quickstartPanel;
		public GameObject documentationPanel;
		//public GameObject updatePanel;
		public GameObject metaConnectedIndicator;
		public GameObject metaNotConnectedIndicator;
		
		public string installedVersion = "0.1.4.2";
		public string latestVersion = "0.1.4.2";
		public bool updateAvailable = false;
		
		public string downloadURL = "http://www.meta-view.com/download";
		public string documentationURL = "https://www.spaceglasses.com/docs/index.html";
		public string tutorialsURL = "https://www.spaceglasses.com/docs/_tutorials.html";
		public string releaseURL = "https://www.spaceglasses.com/docs/_release.html";
		
		public string releaseNotesURL = "https://www.spaceglasses.com/docs/index.html";
		
		//public GameObject updateButton;
		//public GameObject releaseNotesButton;
		
		#endregion
		
		#region MetaBehaviour methods
		
		// Use this for initialization
		private void Start()
		{
			CheckForMetaDevice();
		}
		
		// Update is called once per frame
		private void Update()
		{
			//CheckForUnityEditor();
			CheckForMetaUpdate();
		}
		
		#endregion
		
		#region member methods
		
		public void CheckForMetaDevice()
		{
            if (MetaCore.Instance.depthSensorConnected)
			{
				metaConnectedIndicator.SetActive(true);
				metaNotConnectedIndicator.SetActive(false);
			}
			else
			{
				metaConnectedIndicator.SetActive(false);
				metaNotConnectedIndicator.SetActive(true);
			}
		}
		
		public void CheckForMetaUpdate()
		{
			if (installedVersion != latestVersion)
			{
				updateAvailable = true;
			}
			if (updateAvailable)
			{
				//updateButton.SetActive(true);
				//releaseNotesButton.SetActive(false);
			}
		}
		
		/*public void CheckForUnityEditor()
		{
			if (File.Exists(unityPath))
			{
				unityInstalled = true;
				newProjectButton.SetActive(true);
				installUnityButton.SetActive(false);
			}
			else
			{
				unityInstalled = false;
				newProjectButton.SetActive(false);
				installUnityButton.SetActive(true);
			}
		}*/
		
		/*public void Quickstart()
		{
			state = State.Quickstart;
			welcomePanel.SetActive(false);
			quickstartPanel.SetActive(true);
		}*/
		
		public void Documentation()
		{
			state = State.Documentation;
			welcomePanel.SetActive(false);
			documentationPanel.SetActive(true);
		}
		
		public void OfflineDocs()
		{
			MetaSpace.OpenURL(documentationURL);
		}
		
		
		public void Tutorials()
		{
            MetaSpace.OpenURL(tutorialsURL);
		}
		
		public void ReleaseNotes()
		{
            MetaSpace.OpenURL(releaseNotesURL);
			
			//state = State.New;
			//welcomePanel.SetActive(false);
			//newPanel.SetActive(true);
		}
		
		public void ReleaseHistory()
		{
            MetaSpace.OpenURL(releaseURL);
		}
		
		
		public void DownloadUpdate()
		{
			state = State.Update;
            MetaSpace.OpenURL(downloadURL);
		}
		
		public void Demos()
		{
			state = State.Demos;
			welcomePanel.SetActive(false);
			demoPanel.SetActive(true);
		}
		
		public void Back()
		{
			state = State.Welcome;
			welcomePanel.SetActive(false);
			//newPanel.SetActive(false);
			//quickstartPanel.SetActive(false);
			//updatePanel.SetActive(false);
			documentationPanel.SetActive(false);
			demoPanel.SetActive(false);
			
			welcomePanel.SetActive(true);
		}
		
		public void LoadDemo()
		{
            MetaSpace.LoadScene("Meta SDK Guide");
		}
		
		public void Restart()
		{
			MetaSpace.LoadScene(Application.loadedLevel);
		}
		
		public void NewProject()
		{
			string newProjectPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\UnityMetaProject";
			if (File.Exists(newProjectPath))
			{
				newProjectPath += UnityEngine.Random.Range(0, 10000f);
				
			}
			string args = " -importPackage '" + tutorialPackagePath + "' -createProject '" + newProjectPath + "\\'";
			UnityEngine.Debug.Log(args);
			System.Diagnostics.Process.Start(unityPath, args);
		}
		
		public void InstallUnity()
		{
            MetaSpace.OpenURL("http://www.unity3d.com/beta/4.6");
		}
		
		public void Quit()
		{
			Application.Quit();
		}
		
		public void LoadCalibration()
		{
			MetaSpace.LoadScene("MetaCalibrateWithFingers");	
		}
		#endregion
	}
}