using UnityEngine;
using System.Collections;

/// Wrapper for references to junctions
public class JunctionData : MonoBehaviour {

	/// Unity has trouble serializing nulls, so consider hasJunction[i] equivalent to junctions[i] == null
	public bool[] hasJunction;
	public GameObject[] junctions;
	/// Radius of the associated collider. So hackish
	public float radius;

	void Start () {
		renderer.enabled = false;
	}

}
