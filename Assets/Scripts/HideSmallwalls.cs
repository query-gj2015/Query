using UnityEngine;
using System.Collections;

public class HideSmallwalls : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		GameObject gob;

		gob = GameObject.FindGameObjectWithTag("FancyBeginning");
		gob.SetActive(false);
		this.gameObject.SetActive(false);

		//Debug.Log (gob.Length);
	}
}
