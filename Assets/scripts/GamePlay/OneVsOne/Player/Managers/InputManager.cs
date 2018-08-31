using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scenes.OneVsOne.UI;

namespace GamePlay.OneVsOne.Player.Managers
{
	public class InputManager : MonoBehaviour {
		[HideInInspector]
		public bool jump;
		[HideInInspector]
		public bool hit;
		[HideInInspector]
		public Vector2 direct;

		public enum TypeOfInput {GraphicalInterface, KeyBoard};
		public TypeOfInput type;
		private UIController UIC;

		void Awake ()
		{
			Messenger.AddListener(UIEventSystem.PLAYER_HIT, OnPlayerHit);
			Messenger.AddListener(UIEventSystem.PLAYER_JUMP, OnPlayerJump);
			Messenger<Vector2>.AddListener(UIEventSystem.PLAYER_DIRECTION, OnPlayerMove);
		}

		void OnDestroy ()
		{
			Messenger.RemoveListener(UIEventSystem.PLAYER_JUMP, OnPlayerJump);
			Messenger.RemoveListener(UIEventSystem.PLAYER_HIT, OnPlayerHit);
			Messenger<Vector2>.RemoveListener(UIEventSystem.PLAYER_DIRECTION, OnPlayerMove);
		}

		void Start ()
		{
			this.UIC = GameObject.Find("UIController").GetComponent<UIController> ();
		}
		
		void Update ()
		{
			switch (this.type)
			{
				case TypeOfInput.KeyBoard:
				this.GetDataFromKeyBoard();
				this.UIC.HideGraphicInterface();
				break;
				case TypeOfInput.GraphicalInterface:
				this.UIC.ShowGraphicInterface();
				break;
			}
		}

		private void GetDataFromKeyBoard ()
		{
			this.jump = Input.GetKeyDown(KeyCode.Space);
			this.hit = Input.GetKeyDown(KeyCode.F);
			this.direct = new Vector2 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		}

		public void OnPlayerMove (Vector2 direct)
		{
			this.direct = direct;
		}

		public void OnPlayerHit ()
		{
			this.hit = true;
		}
		
		public void OnPlayerJump ()
		{
			this.jump = true;
		}

		public void ChangeType (int number)
		{
			switch (number)
			{
				case 0:
				this.type = TypeOfInput.GraphicalInterface;
				break;
				case 1:
				this.type = TypeOfInput.KeyBoard;
				break;
			}
			
		}
	}
}

