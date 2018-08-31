using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes.MainMenu {
	public class MainMenuInit : MonoBehaviour {
		public GameObject GameStations;
		public GameObject OneVsOne;
		public GameObject TeamFight;
		private GameObject games;
		private GameObject gsInstance;

		void Awake ()
		{
			this.gsInstance = GameObject.FindGameObjectWithTag("GameStations");
		}
		void Start ()
		{
			if (this.gsInstance == null)
			{
				Instantiate(this.GameStations, Vector3.zero, Quaternion.identity);
				this.gsInstance = GameObject.FindGameObjectWithTag("ScenesController");
			}
			this.games = GameObject.Find("Games");

			GameObject game = GameObject.FindGameObjectWithTag("Game");
			if (game != null)
			{
				Destroy(game);
			}
		}

		public GameObject StartGame(string name)
		{
			switch(name)
			{
				case "OneVsOne":
					return this.InitGame(this.OneVsOne);
				case "TeamFight":
					return this.InitGame(this.TeamFight);
			}
			return null;
		}

		public void StopGame(string name)
		{
			switch(name)
			{
				case "OneVsOne":
					Destroy(GameObject.Find("OneVsOne"));
					break;
				case "TeamFight":
					Destroy(GameObject.Find("TeamFight"));
					break;	
			}
		}

		private GameObject InitGame (GameObject go)
		{
			return Instantiate(go, Vector3.zero, Quaternion.identity, this.games.transform);
		}
	}
}

