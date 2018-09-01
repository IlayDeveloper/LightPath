using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scenes.Begin;
using Scenes.Begin.UI;

namespace GamePlay.Begin.Models {
	public class BeginModel : MonoBehaviour {

		public UIController UIC;
		private GamePlayController gpController;
		public WinnerTypes winner;
		public enum WinnerTypes
		{
			Reds,
			Blues,
			DeadHead
		}
		
	}
}

