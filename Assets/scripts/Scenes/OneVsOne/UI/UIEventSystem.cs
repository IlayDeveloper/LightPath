using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes.OneVsOne.UI {
	public class UIEventSystem : MonoBehaviour {
		public const string PLAYER_JUMP = "PLAYER_JUMP";
		public const string PLAYER_HIT = "PLAYER_HIT";
		public const string PLAYER_DIRECTION = "PLAYER_DIRECTION";

		public void PlayerJump ()
		{
			Messenger.Broadcast(UIEventSystem.PLAYER_JUMP);
		}

		public void PlayerHit ()
		{
			Messenger.Broadcast(UIEventSystem.PLAYER_HIT);
		}

		public void PlayerDirection (Vector2 direction)
		{
			Messenger<Vector2>.Broadcast(UIEventSystem.PLAYER_DIRECTION, direction);
		}
	}
}

