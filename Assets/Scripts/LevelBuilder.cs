using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {

    public GameObject[] objects;
    public Vector3[] positions;
    public Vector3[] rotations;
    public Vector3[] scales;

	void Start () {

        for (int i = 0; i < objects.Length; i++) {
            GameObject newObject = Instantiate(objects[i], gameObject.transform, false);
            newObject.transform.localPosition = positions[i];
            newObject.transform.localRotation = Quaternion.Euler(rotations[i]);
            newObject.transform.localScale = scales[i];
        }
	}
}
