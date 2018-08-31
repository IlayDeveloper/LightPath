using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scenes.OneVsOne.UI;

namespace GamePlay.OneVsOne.Bot.Managers
{
	public class InputManager : MonoBehaviour {
		[HideInInspector]
		public bool jump;
		[HideInInspector]
		public bool hit;
		[HideInInspector]
		public Vector2 direct;
		private AIModel AIM;
		void Start ()
		{
			this.AIM = GameObject.Find("AIModel").GetComponent<AIModel> ();
		}
		
		void Update ()
		{
		}

		public void Move (Vector2 direct)
		{
			this.direct = direct;
		}

		public void Hit ()
		{
			this.hit = true;
		}
		
		public void Jump ()
		{
			this.jump = true;
		}

	}
}

