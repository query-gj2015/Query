using UnityEngine;
using System.Collections;

public class ReduceVolume : MonoBehaviour {
	
	GameObject[] obj;

	void Awake()
	{
		obj = GameObject.FindGameObjectsWithTag("AudioSource");
	}

	void FixedUpdate ()
	{
		int i;
		float sum = 0f;

		for(i=0; i<obj.Length; i++)
		{
			obj[i].audio.volume = obj[i].audio.volume - 0.03f;

			sum += obj[i].audio.volume;
		}

		if(sum < 0.5)
			Application.LoadLevel ("room2");
	}
}
