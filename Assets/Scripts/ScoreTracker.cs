using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

	public Text scoreText;
	public int multiplier;
	public GameObject player;

	private float score;

	void Start() {
		score = 0;
	}

	void Update() {
		score = Mathf.Floor (player.transform.position.y * multiplier) > score ? Mathf.Floor (player.transform.position.y * multiplier) : score;
		scoreText.text = "Score: " + score;
	}

	public float GetScore() {
		return score;
	}
}
