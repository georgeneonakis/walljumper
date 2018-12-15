using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCleanup : MonoBehaviour {

	public Transform boundary;

	void Update() {
		Vector2 corner = (Vector2)Camera.main.ScreenToWorldPoint (new Vector3 (0, 0, 0));
		float lowerBound = corner.y;

		if (boundary.position.y < lowerBound) {
			Destroy (gameObject);
		}
	}
}
