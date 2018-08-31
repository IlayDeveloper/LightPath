using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamePlay.OneVsOne.Ball;

namespace GamePlay.OneVsOne.Models{
	public class GateModel : MonoBehaviour {

		public Text labelScore;
		[HideInInspector]
		public int myPoints = 0;
		public bool isGoal = false;

		void Start () {
			//labelScore.text = myPoints.ToString();
		}
		
		void OnTriggerEnter2D(Collider2D ball)
		{
			if(ball.gameObject.tag == "Ball"){
				this.myPoints++;
				this.isGoal = true;
				labelScore.text = myPoints.ToString();
			}	
		}

		public void Restart()
		{
			this.myPoints = 0;
			this.labelScore.text = "0";
		}
	}
}

