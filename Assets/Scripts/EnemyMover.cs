using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {

	public bool moveLeft = false;
	public float travelSpeed = 5f;
	public float xBoundary = 3f;

	void Update() {
		if (moveLeft) {
			if (gameObject.transform.position.x <= -xBoundary)
				moveLeft = false;
			else {
				Vector2 oldPosition = (Vector2)gameObject.transform.position;
				gameObject.transform.position = new Vector2 (oldPosition.x - travelSpeed * Time.deltaTime, oldPosition.y);
			}
		} else {
			if (gameObject.transform.position.x >= xBoundary)
				moveLeft = true;
			else {
				Vector2 oldPosition = (Vector2)gameObject.transform.position;
				gameObject.transform.position = new Vector2 (oldPosition.x + travelSpeed * Time.deltaTime, oldPosition.y);
			}
		}
	}
}
