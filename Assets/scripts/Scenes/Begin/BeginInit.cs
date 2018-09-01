using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay.Begin.Models;
using GamePlay.Begin;

namespace Scenes.Begin {
	public class BeginInit : MonoBehaviour {
		private BeginModel Model;
		private GamePlayController gpController;

		void Start ()
		{
			/*this.Model =  GameObject.FindGameObjectWithTag("GameStations").GetComponentInChildren<OneVsOneModel> ();
			this.gpController = GameObject.Find("GamePlayController").GetComponent<GamePlayController> ();
			this.AImodel = GameObject.FindWithTag("Bot").GetComponentInChildren<AIModel> ();
			if (this.Model != null){
				this.Init (Model.mode, Model.player);
			}else {
				Debug.Log("Model for MainGame not found");
			}*/
		}
		
		public void Init ()
		{
			/*
			switch (mode)
			{
				case OneVsOneModel.Modes.Offline:
				break;
				case OneVsOneModel.Modes.Online:
				break;
			}
			switch (player)
			{
				case OneVsOneModel.Players.Chan:
				this.SetupObject (this.players[0]);
				break;
				case OneVsOneModel.Players.Lion:
				this.SetupObject (this.players[1]);
				break;
				case OneVsOneModel.Players.Henry:
				this.SetupObject (this.players[2]);
				break;
			}
			this.gpController.GamePlay();
			*/
		}

		private void SetupObject (GameObject go)
		{
			/*string team;
			Vector3 position;
			if (this.Model.mode == OneVsOneModel.Modes.Offline){
				team = "Blue";
				position = new Vector3 (-10, -5, 10);
			} else {
				team = "Red";
				position = new Vector3 (10, -5, 10);
			}
			go.tag = team;
			Transform interactiveObjects = GameObject.Find("TempObjects").transform;
			Instantiate(go, position, Quaternion.identity, interactiveObjects);*/
		}
	}	
}

