using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scenes.OneVsOne;
using Scenes.OneVsOne.UI;
using GamePlay.OneVsOne.Models;
using GamePlay.OneVsOne.Ball;

namespace GamePlay.OneVsOne.Models {
	public class OneVsOneModel : MonoBehaviour {
		public GateModel gateBlue;
		public GateModel gateRed;
		public BallController BC;
		public UIController UIC;
		private GamePlayController gpController;
		public float totalBattleTime = 30;
		public float battleTime = 0;
		public float timeAtBegin;
		public bool gameIsPlay = false;
		public WinnerTypes winner;
		public enum WinnerTypes
		{
			Reds,
			Blues,
			DeadHead
		}
		public enum Modes
		{
			Offline,
			Online
		}
		public enum Players
		{
			Chan,
			Lion,
			Henry
		}
		public enum Teams
		{
			Reds,
			Blues
		}
		public Modes mode;
		public Players player;

		public void Start ()
		{	
			this.gpController = GameObject.Find("GamePlayController").GetComponent<GamePlayController> ();
		}

		public void Update ()
		{
			if (this.gameIsPlay){
				this.battleTime = Time.time - timeAtBegin;

				if (this.gateBlue.isGoal == true){
					this.Goal(OneVsOneModel.Teams.Blues);
				}
				if (this.gateRed.isGoal == true){
					this.Goal(OneVsOneModel.Teams.Reds);
				}
			}
		}

		public void FindLinks ()
		{
			this.gateBlue = GameObject.FindGameObjectWithTag("GateBlue").GetComponent<GateModel> ();
			this.gateRed = GameObject.FindGameObjectWithTag("GateRed").GetComponent<GateModel> ();
			this.BC = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallController> ();
		}

		public void FinishGame ()
		{
			this.gameIsPlay = false;
			this.BallSetActive(false);
			this.CheckWinner();
		}

		public void BeginGame ()
		{
			this.timeAtBegin = Time.time;
			this.ResetScore();
			this.gameIsPlay = true;
			this.BallSetActive(true);
		}

		private void CheckWinner ()
		{
			if(gateBlue.myPoints > gateRed.myPoints)
			{
				this.winner = OneVsOneModel.WinnerTypes.Reds;
			}
			else if(gateBlue.myPoints < gateRed.myPoints)
			{
				this.winner = OneVsOneModel.WinnerTypes.Blues;
			}
			else
			{
				this.winner = OneVsOneModel.WinnerTypes.DeadHead;
			}
		}

		private void Goal (OneVsOneModel.Teams team)
		{
			this.gateBlue.isGoal = false;
			this.gateRed.isGoal = false;
			this.BC.Respawn();
			this.CheckWinner();
			switch (team)
			{
				case OneVsOneModel.Teams.Reds:
					break;
				case OneVsOneModel.Teams.Blues:
					break;
			}
		}

		private void BallSetActive (bool answer)
		{
			if (answer){
				this.BC.gameObject.SetActive(true);
			}else {
				this.BC.Respawn();
				this.BC.gameObject.SetActive(false);
			}
		}

		private void ResetScore ()
		{
			this.gateBlue.Restart();
			this.gateRed.Restart();
		}
	}
}

