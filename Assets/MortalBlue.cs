using UnityEngine;
using System.Collections;

public class MortalBlue : MonoBehaviour {
	

	bool dyin = false;
	float timer = 0;
	
	public void die() {
		dyin = true;
		}

	void Awake ()
	{
		// Set the texture so that it is the the size of the screen and covers it.
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}

	void Update() {
		if (dyin) {
			guiTexture.color = Color.Lerp(guiTexture.color, Color.black, 10.0f * Time.deltaTime);

			timer += Time.deltaTime;
			if (timer > 3f)
				Application.LoadLevel(Application.loadedLevelName); // restart
		}
		
	}
}
