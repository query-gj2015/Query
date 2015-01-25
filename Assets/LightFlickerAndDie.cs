using UnityEngine;
using System.Collections;

public class LightFlickerAndDie : MonoBehaviour {

	bool flicker = false;
	float decrement;
	//bool dead = false;


	static SceneGlobals sceneGlobals = null;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Shadow") {
			flicker = true;
			decrement = light.intensity / 10;
		}
	}

	void Start() {
		if (sceneGlobals == null) {
			GameObject g = GameObject.Find("SceneGlobalThingie");
			sceneGlobals = g.GetComponent<SceneGlobals>();
		}
	}

	// Update is called once per frame
	void Update () {				
		if (flicker) {
				gameObject.light.intensity -= 4f * decrement * Time.deltaTime; // decrementing by delta time is broken, way slower than it should be. Rounding errors?
				if (gameObject.light.intensity <= 0f)
					gameObject.SetActive(false);
			}

		if (sceneGlobals.lightLevel < gameObject.light.intensity)
				gameObject.light.intensity = sceneGlobals.lightLevel;
	}
}
