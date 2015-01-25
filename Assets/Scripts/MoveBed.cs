using UnityEngine;
using System.Collections;

public class MoveBed : MonoBehaviour {

	int moving = 0;
	void OnTriggerEnter(Collider other)
	{
	/*	Animator anim = GetComponent<Animator>();
			
		anim.SetBool("MovingBed", true);
		audio.Play();
	*/
		if (other.gameObject.tag == "Player" && moving == 0) {
			moving = 1;
			//audio.Play();

		}

		if (other.gameObject.name == "Doorstop") {
			moving = -1;
		}

	}

	void Update() {
		if (moving == 1) {
			Debug.Log ("moving");
			Vector3 deltaPos = new Vector3(0f, 0f, Time.deltaTime * 5f);

			deltaPos = transform.localRotation * deltaPos;

			transform.localPosition += deltaPos;

				}

		}
}
