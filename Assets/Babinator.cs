using UnityEngine;
using System.Collections;

public class Babinator : MonoBehaviour {

	ParentBehavior parent;

	public GameObject player;
	
	float timer = 0f;

	void Start() {
		parent = player.GetComponent<ParentBehavior> ();
		}

	void Update () {
		timer += Time.deltaTime;

		if (timer > 1.0f) {
			timer -= Random.Range(0.8f, 1.0f);
				if ((transform.position - player.transform.position).magnitude < 10000) {
					if (Random.Range (0f, 1f) > 0.9) {
						// Make sound, inform player
						gameObject.audio.Play ();
					parent.hearBaby();

				}
				}
			}
	
	}
}
