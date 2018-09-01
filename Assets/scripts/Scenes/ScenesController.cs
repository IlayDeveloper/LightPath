using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes 
{
	public class ScenesController : MonoBehaviour {
		public const string SCENE_LOADED = "SCENE_LOADED";
		public enum Scenes 
		{
			MainMenu,
			Begin,
			Laser

		}
		public float progress;
		public string currentScene = "MainMenu";
		private AsyncOperation operation;

		void Start ()
		{
			//DontDestroyOnLoad(this.gameObject);
		}

		public void ChangeScene (Scenes scene)
		{
			SceneManager.LoadScene("Loader", LoadSceneMode.Additive);

			switch (scene)
			{
				case Scenes.Begin:
					StartCoroutine(LoadScene("Begin"));
					this.currentScene = "Begin";
					break;
				case Scenes.MainMenu:
					StartCoroutine(LoadScene("MainMenu"));
					this.currentScene = "MainMenu";
					break;
			}
		}

		private IEnumerator LoadScene (string scene)
		{
			AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
			while (! operation.isDone){			
				this.progress = Mathf.Clamp01(operation.progress / 0.9f);
				yield return null;
			}
			
			//Run the event scene loaded
			this.SceneLoaded();
		}

		private void SceneLoaded ()
		{
			Messenger.Broadcast(ScenesController.SCENE_LOADED);
		}

	}
}

