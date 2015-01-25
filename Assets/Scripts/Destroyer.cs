using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	MortalBlue mortal;

	// Use this for initialization
	void Start () {
		mortal = GameObject.Find ("Controller").GetComponent<MortalBlue> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			mortal.die(); // Die, mortal
		}
		else
			Destroy (other.gameObject);
	}
}
