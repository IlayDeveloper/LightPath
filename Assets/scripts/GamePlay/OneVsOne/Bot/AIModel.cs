using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay.OneVsOne.Bot.Managers;
using GamePlay.OneVsOne.Ball;
using GamePlay.OneVsOne.Models;
using GamePlay.OneVsOne.Bot.Detectors;

namespace GamePlay.OneVsOne.Bot
{
	public class AIModel : MonoBehaviour {
		public enum Statements
		{
			Fight,
			Defend,
			Turn
		}

		public enum Strategies
		{
			Aggresive,
			Carefully
		}

		public Statements state;
		public Strategies strategy = AIModel.Strategies.Aggresive;
		private InputManager IM;
		private BallController Ball;
		private OneVsOneModel OVOModel;
		private GameObject Player;
		private Transform Bot;
		private HitableDetector BotHitDetector;
		private float dXBallPlayer;
		private float dYBallPlayer;
		private float dXBallBot;
		private float dYBallBot;
		private float dXBotPlayer;
		private float directXBall;
		private float directYBall;
		const float DIRECT_TO_HOME = 1;

		void Start () 
		{
			GameObject obj = GameObject.FindWithTag("Bot");
			this.IM = obj.GetComponentInChildren<InputManager> ();
			this.Bot = obj.transform;
			this.BotHitDetector = obj.GetComponentInChildren<HitableDetector> ();
			//turn on in Real scene
			this.OVOModel = GameObject.FindWithTag("Game").GetComponentInChildren<OneVsOneModel> ();
			//remove in Real scene
			//this.Ball = GameObject.FindWithTag("Ball").GetComponent<BallController> ();
			//this.Player = GameObject.FindWithTag("Blue");
			//=========================================================================
		}
		
		void Update () 
		{
		}

		void FixedUpdate ()
		{
			this.ComputeDistances();
			this.CheckGameState();
			this.GetDirection();
		}

		public void BotInit ()
		{
			this.Ball = GameObject.FindWithTag("Ball").GetComponent<BallController> ();
			this.Player = GameObject.FindWithTag("Blue");
		}

		public void GetDirection ()
		{
			Vector2 direct = Vector2.zero;
			switch (this.state)
			{
				case AIModel.Statements.Defend:
					direct.x = AIModel.DIRECT_TO_HOME;
					break;
				case AIModel.Statements.Fight:
					direct.x = this.directXBall;
					break;	
				case AIModel.Statements.Turn:
					direct.x = AIModel.DIRECT_TO_HOME;
					break;
			}	
			this.IM.Move(direct);
		}

		private void TryToHit ()
		{
			this.IM.Hit();
		}

		private void TryToJump ()
		{
			this.IM.Jump();
		}

		private void ComputeDistances ()
		{
			float dXBallBot = this.Ball.transform.position.x - this.Bot.position.x;
			float dYBallBot = this.Ball.transform.position.y - this.Bot.position.y;

			float dXBallPlayer = this.Ball.transform.position.x - this.Player.transform.position.x;
			float dYBallPlayer = this.Ball.transform.position.y - this.Player.transform.position.y;

			float dXBotPlayer = this.Bot.position.x - this.Player.transform.position.x;

			this.dXBallBot = Mathf.Abs(dXBallBot);
			this.dYBallBot = Mathf.Abs(dYBallBot);
			this.directXBall = Mathf.Sign(dXBallBot);
			this.directYBall = Mathf.Sign(dYBallBot);

			this.dXBallPlayer = Mathf.Abs(dXBallPlayer);
			this.dYBallPlayer = Mathf.Abs(dYBallPlayer);

			this.dXBotPlayer = Mathf.Abs(dXBotPlayer);
		}

		private void CheckGameState ()
		{
			this.ChooseStrategy ();
			switch (this.strategy)
			{
				case AIModel.Strategies.Aggresive:
					this.AggresiveBehavior();
					break;
				case AIModel.Strategies.Carefully:
					this.CarefullyBehavior();
					break;
			}
		}

		private void AggresiveBehavior ()
		{
			this.TryJumpToBall();
			this.TryToHitPlayer();
			if (this.dXBallBot <= (this.dXBallPlayer + 25))
			{
				this.state = AIModel.Statements.Fight;

				if ((this.BotHitDetector.radiusDetection / 2) >= this.dXBallBot)
				{
					if ( this.directXBall < 0 )
					{
						this.TryToHit();
					}
					else
					{
						this.TryToJump();
						this.state = AIModel.Statements.Defend;
					}
				}
			}
			else
			{
				this.state = AIModel.Statements.Defend;
			}
		}

		private void CarefullyBehavior ()
		{
			this.TryJumpToBall();
			this.TryToHitPlayer();
			if (this.dXBallBot <= this.dXBallPlayer)
			{
				this.state = AIModel.Statements.Fight;
				if ((this.BotHitDetector.radiusDetection / 2) >= this.dXBallBot)
				{
					if ( this.directXBall < 0 )
					{
						this.TryToHit();
					}
					else
					{
						this.TryToJump();
						this.state = AIModel.Statements.Defend;
					}
				}
			}
			else
			{
				this.state = AIModel.Statements.Defend;
			}
		}

		private void ChooseStrategy ()
		{
			if (this.OVOModel.winner == OneVsOneModel.WinnerTypes.Reds)
			{
				this.strategy = AIModel.Strategies.Carefully;
			}
			else
			{
				this.strategy = AIModel.Strategies.Aggresive;
			}
		}

		private void TryJumpToBall ()
		{
			if (this.dXBallBot < this.BotHitDetector.radiusDetection && this.dYBallBot > this.BotHitDetector.radiusDetection/2)
			{
				this.TryToJump();
			}
		}

		private void TryToHitPlayer ()
		{
			if (this.dXBotPlayer < this.BotHitDetector.radiusDetection)
			{
				this.TryToHit();
			}
		}
	}
}

