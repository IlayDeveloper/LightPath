using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.OneVsOne.Bot.Detectors {
	public class GroundDetector : MonoBehaviour {
		public bool isGrounded;
		public Transform groundOfPlayer;
		public float groundPenetration = .1f;
		public LayerMask whatIsGround;
		public Method method = Method.CheckOverLap;
		public enum Method {CheckCollision, CheckOverLap, RayCaster};

		void FixedUpdate ()
		{
			switch (this.method)
			{
				case Method.CheckOverLap:
					this.CheckOverLap();
					break;
			}
		}

		private void CheckOverLap ()
		{
			isGrounded = false;
			// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
			// This can be done using layers instead but Sample Assets will not overwrite your project settings.
			Collider2D[] colliders = Physics2D.OverlapCircleAll(groundOfPlayer.position, groundPenetration, whatIsGround);
			for (int i = 0; i < colliders.Length; i++)
			{
				if (colliders[i].gameObject != gameObject)
					isGrounded = true;
			}
		}
	}
}
