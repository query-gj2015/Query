using UnityEngine;
using System.Collections;

public class ShadowBehavior : MonoBehaviour {

	public GameObject player;
	
	public ArrayList playerPath;

	public float speed;

	/// Length of the plane model to which this script is attached (might wanna use mesh.bounds instead)
	public float planeLength;

	const float epsilon = 0.8f;

	Vector3 target;
	GameObject targetCell;

	void OnTriggerEnter(Collider other) {
		// Have we entered a cell? And do we not know where to go?
		if (other.gameObject.tag == "BoundgingWall" || (other.gameObject.tag == "Cell" && targetCell == null)) { // might wanna change type to InnerCell
			seekPlayer (null);
		}
	}

	void OnTriggerStay(Collider other) {
		// Are we at a destination?
		if (other.gameObject.tag == "InnerCell" && targetCell != null && other.gameObject.transform.parent.gameObject == targetCell) {
			// I guess we've reached our target cell?
			seekPlayer (targetCell);
		}
	}

	void seekPlayer(GameObject cell) {
		// First, leap to given cell
		//if (cell) transform.parent.localPosition = target;
		transform.parent.localScale = new Vector3 (0.01f, 0.01f, 0.01f);

		// From there, search for next cell
		PathTracker tracker = player.GetComponent<PathTracker> ();
		targetCell = tracker.nextCell (cell);
		if (targetCell == null) {
						// Player hasn't reached the next cell yet. We'll look again when we reach it
						target = new Vector3 (-10000, -10000, -10000);
						//Debug.Log ("Not found");
						transform.parent.localScale = new Vector3 (1, 1, 1);
						return;
			}
				

		target = targetCell.transform.position;
		target.y += 0.05f;
	
		// TODO: spooky effects, maybe a bending around the junction animation
		transform.parent.LookAt (target);

		transform.parent.localScale = new Vector3 (1, 1, 1);

		//Debug.Log ("Found cell " + target + " now facing " + transform.parent.localRotation + " | " + transform.rotation);
	}

	void Start() {
		target = new Vector3 (-10000, -10000, -10000);
		targetCell = null;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 deltaPos = new Vector3 (0.0f, 0.0f, Time.deltaTime * speed);
		deltaPos = transform.parent.localRotation * deltaPos;
		transform.parent.localPosition += deltaPos;
		//Vector3 position = transform.parent.localPosition;
		//position.z += Time.deltaTime  * speed; // note that this is twice as fast as the previous implementation (for same scaleRate)
		//transform.parent.localPosition = position;
	}
}
