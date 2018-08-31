using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.OneVsOne.Ball{
	public class BallController : MonoBehaviour {
		public float maxSpeed;
		private Rigidbody2D rb;
		void Start () 
		{
			this.rb = GetComponent<Rigidbody2D>();
		}

		void FixedUpdate ()
		{
			this.rb.velocity = Vector2.ClampMagnitude(this.rb.velocity, this.maxSpeed);
		}

		public void Respawn ()
		{
			transform.position = new Vector3(0, 10, 10);
			rb.velocity = new Vector2(0, 0);
		}

		private void ConstraintPisition ()
		{
			//TODO: сделать ограничения на максимальное пермещение по вретикали и горизонтали по сцене
		}
	}
}

