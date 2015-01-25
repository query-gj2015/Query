using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

	GameObject gob;

	int counter = 63;
	bool flicker = false;
	bool doorlight = false;
	float timer = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (flicker)
		{
			if (timer < Time.time)
			{
				timer = Time.time + Random.Range (0.01F, 0.1F);
				gob.light.intensity = Random.Range (0.3F, 1.5F);
				counter--;

				if (counter == 0)
				{
					GameObject.FindGameObjectWithTag("Light").light.enabled = false;
					gob.light.enabled = false;
					flicker = false;
					doorlight = true;

					timer = Time.time + 2.0f;

					gob = GameObject.FindGameObjectWithTag("DoorLight");
				}
			}
		}
		else if(doorlight)
		{
			if(timer < Time.time)
			{
				doorlight = false;
				gob.light.enabled = true;

				audio.Play ();
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		//this.gameObject.SetActive(false);

		gob = GameObject.FindGameObjectWithTag("FlickeringLight");

		flicker = true;

//		Debug.Log ("Flickering");
	}
}
