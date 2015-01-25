using UnityEngine;
using System.Collections;

public class Tagg : MonoBehaviour {
	private float timer=-1f;

	private GameObject cardboardThingie;
	private bool playing = false;

	// Use this for initialization
	void Start () {
		cardboardThingie = GameObject.Find ( "goalnefesh");
	}
	
	// Update is called once per frame
	void Update () {
		if (timer >= 0f) {
		timer += Time.deltaTime;
			Vector3 t = cardboardThingie.transform.position;
			t.y += Time.deltaTime * 1f;
			if (t.y > 2.5f)
				t.y = 2.5f;
			cardboardThingie.transform.position = t;
		if (timer > 1f && playing==false)
			{
				GameObject h = GameObject.Find("Controller");
				h.GetComponent<AudioSource>().Play();
				Debug.Log("h");
				playing=true;
			}
		if (timer > 5f)
		{
			//timer += Time.deltaTime;
			Destroy (GameObject.Find ("dw"));
			Destroy (GameObject.Find ("bad collapse"));
				if (timer > 7f)
				{
					timer += Time.deltaTime;
					Destroy (GameObject.Find ("screen"));
				}
			}
		}
				
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			timer = 0f;
			//GameObject g = GameObject.Find("bed");
			//g.GetComponent<AudioSource>().Play();
		}

	}
}
