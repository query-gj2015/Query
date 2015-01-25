using UnityEngine;
using System.Collections;

public class ParentBehavior : MonoBehaviour {

	private float timer = -1.0f;

	private float cooldown = 0f;

	public void hearBaby() {
		timer = Time.time - Random.Range (0f, 2f);
	}

	// Update is called once per frame
	void Update () {
		if (timer > 0f && (Time.time - timer > 5f) && Time.time > cooldown) {
			if (Random.Range (0f, 1f) > 0.1) {
				// Respond to baby
				gameObject.audio.Play();
				cooldown = Time.time + 6f;
			}

			timer = -1.0f;
		}
	}

}
