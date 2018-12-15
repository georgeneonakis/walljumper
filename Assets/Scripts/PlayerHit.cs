using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour {

	private GameOver gameOver;

	void Awake() {
		gameOver = Camera.main.GetComponent<GameOver> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			PlayerJump playerJump = other.gameObject.GetComponent<PlayerJump> ();
			if (playerJump.hasBoost) {
				Destroy (gameObject);
			} else if (playerJump.hasShield) {
				playerJump.hasShield = false;
				SpriteRenderer sr = other.gameObject.GetComponent<SpriteRenderer> ();
				sr.color = new Color (0, 255, 0, 255);
				Destroy (gameObject);
			}
			else
				StartCoroutine (gameOver.TriggerGameOver ());
		}
	}
}
