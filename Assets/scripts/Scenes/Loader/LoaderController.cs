using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Loader {
	public class LoaderController : MonoBehaviour {
		public Slider slider;
		public ScenesController sc;
		void Update () {
			slider.value = sc.progress;
		}
	}
}

