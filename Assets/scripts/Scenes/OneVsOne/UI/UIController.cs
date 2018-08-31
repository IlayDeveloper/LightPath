﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamePlay.OneVsOne.Models;
using GamePlay.OneVsOne;

namespace Scenes.OneVsOne.UI {
	public class UIController : MonoBehaviour {
		public Text textTime;
		public enum Menus
		{
			Victory,
			Lose,
			Pause,
			All
		}
		private ScenesController SC;
		private GamePlayController GPC;
		private GameObject graphicManipulators;
		private OneVsOneModel OneVsOneModel;
		public GameObject MenuVictory;
		public GameObject MenuLose;
		public GameObject MenuPause;
		void Start () {
			this.SC = GameObject.FindGameObjectWithTag("ScenesController").GetComponent<ScenesController> ();
			this.graphicManipulators = GameObject.FindGameObjectWithTag("GraphicManipulators");
			this.OneVsOneModel = GameObject.FindGameObjectWithTag("Game").GetComponentInChildren<OneVsOneModel> ();
			this.GPC = GameObject.Find("GamePlayController").GetComponent<GamePlayController> ();
		}

		void Update ()
		{
			this.textTime.text = this.OneVsOneModel.battleTime.ToString();
		}

		public void GoToScene (string name)
		{
			switch (name)
			{
				case "OneVsOne":
				this.SC.ChangeScene(ScenesController.Scenes.OneVsOne);
				break;
				case "MainMenu":
				this.SC.ChangeScene(ScenesController.Scenes.MainMenu);
				break;
				default:
				Debug.Log("Scene with name - " + name + " not found");
				break;
			}
		}

		public void ShowGraphicInterface()
		{
			if (this.graphicManipulators){
				this.graphicManipulators.SetActive(true);
			}
		}

		public void HideGraphicInterface()
		{
			if (this.graphicManipulators){
				this.graphicManipulators.SetActive(false);
			}
		}

		public void ShowMenu(UIController.Menus name)
		{
			switch(name)
			{
				case UIController.Menus.Victory:
					this.MenuVictory.SetActive(true);
					break;
				case UIController.Menus.Lose:
					this.MenuLose.SetActive(true);
					break;
				case UIController.Menus.Pause:
					this.MenuPause.SetActive(true);
					break;
			}
		}

		public void HideMenu(UIController.Menus name)
		{
			switch(name)
			{
				case UIController.Menus.Victory:
					this.MenuVictory.SetActive(false);
					break;
				case UIController.Menus.Lose:
					this.MenuLose.SetActive(false);
					break;
				case UIController.Menus.Pause:
					this.MenuPause.SetActive(false);
					break;
				case UIController.Menus.All:
					this.MenuVictory.SetActive(false);
					this.MenuLose.SetActive(false);
					this.MenuPause.SetActive(false);
					break;
			}
		}

		public void GetMoreBalls ()
		{

		}

		public void NewBattle ()
		{
			this.GPC.GameRestart();
		}

		public void ResumeGame ()
		{
			this.GPC.GameResume();
		}

		public void OpenMenuPause ()
		{
			this.GPC.GamePause();
		}
	}
}

