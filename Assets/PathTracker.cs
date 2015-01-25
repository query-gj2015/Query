using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// Script for keeping track of a player's path through a maze
public class PathTracker : MonoBehaviour {

	List<GameObject> path;

	// Use this for initialization
	void Start () {
		path = new List<GameObject> ();
	}

	public GameObject lastCell() {
			// Hack: trim the path
			GameObject result = path [path.Count - 1];
			path = new List<GameObject> ();
			path.Add(result);
		    return result;			
		}

	public GameObject nextCell(GameObject cell) {
		if (cell == null && path.Count != 0)
				return path[0];

		int i;
		for (i = 0; i < path.Count - 1; ++i) {
			if (path[i] == cell) {
				if (i > 0)
					throw new System.Exception("This shouldn't happen");
				// Hack: trim the path before the result
				GameObject result = path[i + 1];
				path.RemoveRange(0, i + 1);
				return result;
			}
		}

		//Debug.Log ("Cell not found, " + i);
		return null;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Cell" && (path.Count == 0 || path[path.Count - 1] != other.gameObject)) {
			//Debug.Log ("Adding cell " + other.gameObject.transform.position);
			path.Add(other.gameObject);


		}
	}
}