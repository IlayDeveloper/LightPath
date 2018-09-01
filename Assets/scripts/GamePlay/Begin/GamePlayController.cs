using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scenes.Begin.UI;
using Scenes;
using GamePlay.Begin.Models;
using Scenes.Begin;

namespace GamePlay.Begin
{
	public class GamePlayController : MonoBehaviour {
		private ScenesController SC;
		private UIController UIC;
		private BeginModel Model;
		private BeginInit Init;
		void Start () 
		{
			this.SC = GameObject.FindGameObjectWithTag("ScenesController").GetComponent<ScenesController> ();
			this.Model = GameObject.Find("BeginModel").GetComponent<BeginModel> ();
			Messenger.AddListener(ScenesController.SCENE_LOADED, FindLinks);
		}

		void Update ()
		{
		}

		public void GamePlay ()
		{
			/*this.UIC = GameObject.Find("UIController").GetComponent<UIController> ();
			this.Init = GameObject.Find("StartUp").GetComponent<BeginInit> ();
			Time.timeScale = 1;
			
			this.Init.InitBall();
			this.Init.InitAI();
			this.Model.FindLinks();
			this.Model.BeginGame();*/
		}

		public void GameRestart ()
		{
		
		}

		public void GameOver ()
		{
			
		}

		public void GamePause ()
		{
			Time.timeScale = 0;
			this.UIC.ShowMenu(UIController.Menus.Pause);
		}

		public void GameResume ()
		{
			this.UIC.HideMenu(UIController.Menus.All);
			Time.timeScale = 1;
		}

		public void ShowWinMenu ()
		{
			this.UIC.ShowMenu(UIController.Menus.Victory);
		}

		public void ShowLoseMenu ()
		{
			this.UIC.ShowMenu(UIController.Menus.Lose);
		}

		private void FindLinks ()
		{
			this.UIC = GameObject.Find("UIController").GetComponent<UIController> ();
		}
	}
}

