using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scenes.OneVsOne.UI;
using Scenes;
using GamePlay.OneVsOne.Models;
using Scenes.OneVsOne;

namespace GamePlay.OneVsOne
{
	public class GamePlayController : MonoBehaviour {
		private ScenesController SC;
		private UIController UIC;
		private OneVsOneModel Model;
		private OneVsOneInit Init;
		void Start () 
		{
			this.SC = GameObject.FindGameObjectWithTag("ScenesController").GetComponent<ScenesController> ();
			this.Model = GameObject.Find("OneVsOneModel").GetComponent<OneVsOneModel> ();
		}

		void Update ()
		{
			if (this.Model.battleTime >= this.Model.totalBattleTime){
				this.GameOver();
			}
		}

		public void GamePlay ()
		{
			this.UIC = GameObject.Find("UIController").GetComponent<UIController> ();
			this.Init = GameObject.Find("StartUp").GetComponent<OneVsOneInit> ();
			Time.timeScale = 1;
			
			this.Init.InitBall();
			this.Init.InitAI();
			this.Model.FindLinks();
			this.Model.BeginGame();
		}

		public void GameRestart ()
		{
			this.Model.FinishGame();
			this.Model.BeginGame();
			this.GameResume();
		}

		public void GameOver ()
		{
			this.Model.FinishGame();
			if (this.Model.mode == OneVsOneModel.Modes.Offline)
			{
				switch(this.Model.winner)
				{
					case OneVsOneModel.WinnerTypes.Blues:
						this.ShowWinMenu();
						break;
					case OneVsOneModel.WinnerTypes.Reds:
						this.ShowLoseMenu();
						break;
					case OneVsOneModel.WinnerTypes.DeadHead:
						this.PlayAddingTime();
						break;
				}
			}

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

		public void PlayAddingTime ()
		{
			//Дополнительное время в случае ничьи
		}

		public void ShowWinMenu ()
		{
			this.UIC.ShowMenu(UIController.Menus.Victory);
		}

		public void ShowLoseMenu ()
		{
			this.UIC.ShowMenu(UIController.Menus.Lose);
		}
	}
}

