using UnityEngine;
using System.Collections;

public class Portal4 : MonoBehaviour {

	const int nextLevel = 5; // Gotta hardcode because Unity is being dumb

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player")
				Application.LoadLevel ("room6");
	
	}
}
