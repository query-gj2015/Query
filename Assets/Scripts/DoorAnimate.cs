using UnityEngine;
using System.Collections;

public class DoorAnimate : MonoBehaviour {

	bool musicFade = false;
	bool Level2WaitForExitFirst = false;

	float time = 0f;

	GameObject[] obj;

	void OnLevelWasLoaded()
	{
		if(Application.loadedLevelName == "room2")
			Level2WaitForExitFirst = true;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(Level2WaitForExitFirst == false)
		{
			Animator anim = GetComponent<Animator>();
			
			audio.Play();
			anim.SetBool("Open", true);
		}

		if(Application.loadedLevelName == "room1")
		{
			obj = new GameObject[2];
			obj[0] = GameObject.FindGameObjectWithTag("Player");
			obj[1] = GameObject.FindGameObjectWithTag("AudioSource");
			musicFade = true;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if(Level2WaitForExitFirst == true)
			Level2WaitForExitFirst = false;
	}

	void FixedUpdate ()
	{
		if(musicFade == true && Time.time > time)
		{
			float sum = 0f;

			foreach(GameObject src in obj)
			{
				if(src.audio.volume > 0f)
				{
					src.audio.volume -= 0.1f;
					sum += src.audio.volume;
				}
			}

			if(sum > 0)
				time = Time.time + 0.4f;
			else
				musicFade = false;
		}
	}
}
