using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamePlay.Begin.Models;

namespace Scenes.MainMenu.UI {

	public class UIController : MonoBehaviour {

		public GameObject modeSettings;
		public GameObject playerSettings;
		private BeginModel OneVsOneModel;
		private ScenesController sc;
		private MainMenuInit MainMenuInit;

		void Start ()
		{
			this.sc = GameObject.FindGameObjectWithTag("ScenesController").GetComponent<ScenesController> ();
			this.MainMenuInit = GameObject.Find("StartUp").GetComponent<MainMenuInit> ();
		}

		public void GoToScene (string name)
		{
			switch (name)
			{
				case "Begin":
					this.MainMenuInit.StartGame("Begin");
					this.sc.ChangeScene(ScenesController.Scenes.Begin);
					break;
				case "TeamFight":
					this.sc.ChangeScene(ScenesController.Scenes.Laser);
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
