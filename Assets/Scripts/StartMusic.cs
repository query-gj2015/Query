using UnityEngine;
using System.Collections;

public class StartMusic : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		other.audio.Play();
	}
}
