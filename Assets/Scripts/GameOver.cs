using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public Text gameOverText;
	public Transform player;
	public PlayerJump playerJump;

	private float lowerBound;

	void Start () {
		gameOverText.text = "";
		lowerBound = -10f;
	}

	void Update() {
		Vector2 corner = (Vector2)Camera.main.ScreenToWorldPoint (new Vector3 (0, 0, 0));
		lowerBound = corner.y;

		if (player.position.y < lowerBound) {
			StartCoroutine(TriggerGameOver ());
		}
	}

	public IEnumerator TriggerGameOver() {
		playerJump.DisableControls();
		gameOverText.text = "Game Over!";
		yield return new WaitForSeconds(2f);
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}
}
