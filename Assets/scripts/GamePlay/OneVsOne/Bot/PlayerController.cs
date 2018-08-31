using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay.OneVsOne.Bot.Detectors;
using GamePlay.OneVsOne.Bot.Managers;

namespace GamePlay.OneVsOne.Bot
{
	[RequireComponent(typeof(InputManager))]
	[RequireComponent(typeof(MovementManager))]
	[RequireComponent(typeof(HitManager))]
	public class PlayerController : MonoBehaviour {
		private InputManager mInput;
		private MovementManager mMovement;
		private HitManager mHit;

		void Awake ()
		{
			this.mInput = gameObject.GetComponentInChildren( typeof(InputManager) ) as InputManager;
			this.mMovement = gameObject.GetComponentInChildren( typeof(MovementManager) ) as MovementManager;
			this.mHit = gameObject.GetComponentInChildren( typeof(HitManager) ) as HitManager;
		}
		void FixedUpdate ()
		{
			mMovement.Move(mInput.direct, mInput.jump);
			mHit.TryHit(mInput.hit, mInput.direct);
			mInput.jump = false;
			mInput.hit = false;
		}
	}

}
