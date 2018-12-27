using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {

    private SpriteRenderer sprite;
	public bool moveLeft = false;
	public float travelSpeed = 5f;
	public float xBoundary = 3f;

    void Start()
    {
        sprite = GetComponentsInChildren<SpriteRenderer>()[0];
        if (moveLeft)
            sprite.flipX = true;
    }

    void Update() {
        if (moveLeft) {
            if (gameObject.transform.position.x <= -xBoundary) {
                moveLeft = false;
                sprite.flipX = false;
            }
            else
            {
                Vector2 oldPosition = (Vector2)gameObject.transform.position;
                gameObject.transform.position = new Vector2(oldPosition.x - travelSpeed * Time.deltaTime, oldPosition.y);
            }
        } else {
            if (gameObject.transform.position.x >= xBoundary) {
                moveLeft = true;
                sprite.flipX = true;
            }
			else {
				Vector2 oldPosition = (Vector2)gameObject.transform.position;
				gameObject.transform.position = new Vector2 (oldPosition.x + travelSpeed * Time.deltaTime, oldPosition.y);
			}
		}
	}
}
