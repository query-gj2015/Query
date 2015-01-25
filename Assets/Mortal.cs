using UnityEngine;
using System.Collections;

public class Mortal : MonoBehaviour {

	static SceneGlobals sceneGlobals = null;

	bool dyin = false;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Shadow") {
			AudioSource audio = other.gameObject.GetComponent<AudioSource>();
			dyin = true;
			audio.Play();

			GetComponent<CharacterController> ().enabled = false;
		}
	}

	void Start() {
			if (sceneGlobals == null) {
				GameObject g = GameObject.Find("SceneGlobalThingie");
				sceneGlobals = g.GetComponent<SceneGlobals>();
			}

		}

	void Update() {
		if (dyin) {
			sceneGlobals.lightLevel -= 0.5f * Time.deltaTime;

			if (sceneGlobals.lightLevel < -0.2f)
				Application.LoadLevel(Application.loadedLevelName); // restart
		}

	}
}
