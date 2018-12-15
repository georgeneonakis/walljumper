using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerup : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		PlayerJump playerJump = other.gameObject.GetComponent<PlayerJump> ();
		playerJump.hasShield = true;
		SpriteRenderer spriteRenderer = other.gameObject.GetComponent<SpriteRenderer> ();
		spriteRenderer.color = new Color (255, 187, 0, 255);
		Destroy (gameObject);
	}
}
