using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour {

	private LevelGenerator levelGenerator;

	void Awake() {
		levelGenerator = Camera.main.GetComponent<LevelGenerator>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			levelGenerator.GenerateLevel (transform.position.y + 5);
			Destroy (this);
		}
	}		
}
