using UnityEngine;
using System.Collections;

public class Collapse : MonoBehaviour {
	
	private float timer=2f;
	private int i=1;
	private int j=101;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer>0.3f && i<31)
		{
			Destroy(GameObject.Find ("dr"+i));
			Destroy(GameObject.Find ("dr"+j));
			Destroy(GameObject.Find ("s"+(i-1)));
			if(i==30){
				//Destroy(GameObject.Find ("dw"));
				Destroy(GameObject.Find ("s29"));
				Destroy(GameObject.Find ("s30"));
			}
			timer=0f;
			i++;
			j++;
		}
	
	}
}
