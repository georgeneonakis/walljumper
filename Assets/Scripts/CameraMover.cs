using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {

	public Transform player;
	public float offset;

	void Update() {
		if (player.position.y + offset > transform.position.y) {
			Vector2 cameraPosition = transform.position;
			cameraPosition.y = player.position.y + offset;
			transform.position = cameraPosition;
		}
	}
}
