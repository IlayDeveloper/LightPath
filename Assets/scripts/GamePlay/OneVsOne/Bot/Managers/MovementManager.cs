using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay.OneVsOne.Bot.Detectors;

namespace GamePlay.OneVsOne.Bot.Managers
{

	public class MovementManager : MonoBehaviour {
		private Rigidbody2D rb;
		private Animator animator;
		private bool facingRight = true;
		public float maxSpeed;
		public float jumpForce;
		public GroundDetector groundDetector;
		public AirControllMod airControll;
		public enum AirControllMod {Full, Half, None};
		public bool canAirJump;

		void Awake ()
		{
			this.rb = gameObject.GetComponentInParent( typeof(Rigidbody2D) ) as Rigidbody2D;
			this.animator = GetComponent<Animator>();
		}

		public void Move (Vector2 _direct, bool _jump)
		{
			/* Velocity Controller */
			Vector2 newVelocity;
			if (groundDetector.isGrounded || airControll == AirControllMod.Full) 
			{
				newVelocity = new Vector2(_direct.x * this.maxSpeed, this.rb.velocity.y);
			} 
			else if(! groundDetector.isGrounded && airControll == AirControllMod.Half)
			{
				newVelocity = new Vector2(_direct.x * this.maxSpeed * 0.4f, this.rb.velocity.y);
			} 
			else {
				newVelocity = this.rb.velocity;
			}
			this.rb.velocity = Vector2.ClampMagnitude(newVelocity, this.maxSpeed);

			/* Jump Controller */
			if (_jump && groundDetector.isGrounded) {
				Vector2 force = new Vector2(0f, this.jumpForce);
				this.rb.AddForce(force, ForceMode2D.Impulse);
			}

			/* AirJump Controller */
			if (_jump && ! groundDetector.isGrounded && this.canAirJump) {
				this.canAirJump = false;
				Vector2 force = new Vector2(0f, this.jumpForce);
				this.rb.AddForce(force, ForceMode2D.Impulse);
			}
			
			//reset can air jump
			if (groundDetector.isGrounded){
				this.canAirJump = true;
			}

			this.FacingControll(_direct.x);
		}

		private void FacingControll (float _direction)
		{
			if (_direction > 0 && ! this.facingRight)
			{
				Flip();
			}
			if (_direction < 0 && this.facingRight)
			{
				Flip();
			}
		}

		private void Flip ()
		{
			this.facingRight = ! this.facingRight;

			Vector3 currentScale = this.rb.transform.localScale;
			currentScale.x *= (-1);
			this.rb.transform.localScale = currentScale;
		}
	}
}

