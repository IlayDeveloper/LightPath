using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay.OneVsOne.Player.Detectors;

namespace GamePlay.OneVsOne.Player.Managers
{
	[RequireComponent(typeof(HitableDetector))]
	public class HitManager : MonoBehaviour {
		public HitableDetector hd;
		public float hitBallForce;
		public float hitPlayerForce;
		public float hitBotForce;

		public void TryHit (bool hit, Vector2 direct)
		{
			if (hit && hd.canHit){
				this.Hit (direct);
			}
		}

		private void Hit (Vector2 direct)
		{
			Rigidbody2D rb = hd.ojectForHit.GetComponent<Rigidbody2D> ();
			switch (hd.ojectForHit.tag)
			{
				case "Ball":
				Vector2 force = new Vector2 (hd.direction, direct.y) * this.hitBallForce;
				rb.AddForce (force, ForceMode2D.Impulse);
				break;
				case "Reds":
				rb.AddForce (new Vector2(this.hitPlayerForce * hd.direction, this.RandomYForce(-50, 50)), ForceMode2D.Impulse);
				break;
				case "Blue":
				rb.AddForce (new Vector2(this.hitPlayerForce * hd.direction, this.RandomYForce(-50, 50)), ForceMode2D.Impulse);
				break;
				case "Bot":
				rb.AddForce (new Vector2(this.hitBotForce * hd.direction, this.RandomYForce(-50, 50)), ForceMode2D.Impulse);
				break;
			}
		}

		private float RandomYForce (float min, float max)
		{
			return Random.Range(min, max);
		}
	}

}