using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public GameObject[] easyLevels;
	public GameObject[] intermediateLevels;
	public GameObject[] hardLevels;
	public GameObject[] expertLevels;
	public ScoreTracker scoreTracker;
    public int easyThreshold;
    public int medThreshold;
    public int hardThreshold;

	public void GenerateLevel(float position) {
		float score = scoreTracker.GetScore ();
		if (score < easyThreshold) {
			Generate (easyLevels, position);
		} else if (score < medThreshold) {
			Generate (intermediateLevels, position);
		} else if (score < hardThreshold) {
			Generate (hardLevels, position);
		} else {
			Generate (expertLevels, position);
		}
	}

	void Generate(GameObject[] levels, float position) {
		GameObject newLevel = levels [Random.Range (0, levels.Length)];
		Instantiate (newLevel, new Vector3 (0, position, 0), Quaternion.identity);
	}		
		
}
