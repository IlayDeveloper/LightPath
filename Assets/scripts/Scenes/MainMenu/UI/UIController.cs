using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamePlay.OneVsOne.Models;
using GamePlay.TeamFight.Models;

namespace Scenes.MainMenu.UI {

	public class UIController : MonoBehaviour {

		public GameObject modeSettings;
		public GameObject playerSettings;
		private OneVsOneModel OneVsOneModel;
		private TeamFightModel TeamFightModel;
		private ScenesController sc;
		private MainMenuInit MainMenuInit;

		void Start ()
		{
			this.sc = GameObject.FindGameObjectWithTag("ScenesController").GetComponent<ScenesController> ();
			this.MainMenuInit = GameObject.Find("StartUp").GetComponent<MainMenuInit> ();
		}

		public void ShowSettings (string name)
		{
			switch (name)
			{
				case "Mode":
				this.modeSettings.SetActive(true);
				break;
				case "Player":
				this.playerSettings.SetActive(true);
				break;
				default:
				Debug.Log("Undefinde settings - " + name);
				break;
			}
		}

		public void CloseSettings (string name)
		{
			switch (name)
			{
				case "Mode":
				this.modeSettings.SetActive(false);
				break;
				case "Player":
				this.playerSettings.SetActive(false);
				break;
				default:
				Debug.Log("Undefinde settings - " + name);
				break;
			}
		}

		public void SetPlayerOneVsOne (string name)
		{
			switch (name)
			{
				case "Chan":
				this.OneVsOneModel.player = OneVsOneModel.Players.Chan;
				break;
				case "Lion":
				this.OneVsOneModel.player = OneVsOneModel.Players.Lion;
				break;
				case "Henry":
				this.OneVsOneModel.player = OneVsOneModel.Players.Henry;
				break;
				default:
				Debug.Log("Player with name - " + name + " not found");
				break;
			}
		}

		public void SetModeOneVsOne (string mode)
		{
			this.OneVsOneModel = this.MainMenuInit.StartGame("OneVsOne").GetComponentInChildren<OneVsOneModel> ();
			switch (mode)
			{
				case "Offline":
				this.OneVsOneModel.mode = OneVsOneModel.Modes.Offline;
				break;
				case "Online":
				this.OneVsOneModel.mode = OneVsOneModel.Modes.Online;
				break;
				default:
				Debug.Log("Mode - " + mode + " not found");
				break;
			}
		}

		public void GoToScene (string name)
		{
			switch (name)
			{
				case "OneVsOne":
				this.sc.ChangeScene(ScenesController.Scenes.OneVsOne);
				break;
				case "TeamFight":
				this.sc.ChangeScene(ScenesController.Scenes.TeamFight);
				break;
				case "MainMenu":
				this.sc.ChangeScene(ScenesController.Scenes.MainMenu);
				break;
				default:
				Debug.Log("Scene with name - " + name + " not found");
				break;
			}
		}
	}

}
