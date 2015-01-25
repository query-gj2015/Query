using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		switch (Application.loadedLevelName)
		{
			case "room1":
				Application.LoadLevel ("room2");
				break;
			case "room2":
				Application.LoadLevel ("room3");
				break;
			case "room3":
				Application.LoadLevel ("room4");
				break;
			case "room4":
				Application.LoadLevel ("room5");
				break;
			case "room5":
				Application.LoadLevel ("room6");
				break;
			case "room6":
				Application.LoadLevel ("room7");
				break;
		}
	}
}
