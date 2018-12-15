using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPowerup : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		PlayerJump playerJump = other.gameObject.GetComponent<PlayerJump> ();
		playerJump.StartCoroutine ("Boost");
		Destroy (gameObject);
	}
}
