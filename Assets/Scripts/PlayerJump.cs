using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour 
{
	public float gravity = 5.0f;
	public float dashForce = 10f;
	public float dashFalloff = 5f;
	public float boostDuration = 5f;
	public float boostSpeed = 5f;

	[HideInInspector] public bool hasShield = false;
	[HideInInspector] public bool hasBoost = false;

	private Rigidbody2D rb;
	private SpriteRenderer sr;
	private CircleCollider2D coll;
	private Collider2D lastWall;
	private bool hasJumped = false;
	private bool hasDashed = false;
	private bool canMove = true;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		coll = GetComponent<CircleCollider2D> ();
		lastWall = null;
	}

	void Update() {
		if (Input.GetButtonDown ("Fire1") && canMove) 
		{
			if (!hasJumped) {
				Jump ();
			} else if (!hasDashed) {
				StartCoroutine (Dash ());
			}
		}
	}

	void Jump() {
		Vector2 target = Camera.main.ScreenToWorldPoint ((Vector2)Input.mousePosition);
		Vector2 current = rb.transform.position;

		if (target.y >= current.y) 
		{
			float vy = Mathf.Sqrt (2 * gravity * (target.y - current.y));
			float vx = (target.x - current.x) * Mathf.Sqrt (gravity / (2 * (target.y - current.y)));
			Vector2 force = new Vector2 (vx, vy);
			rb.velocity = force;
			hasJumped = true;
		}
		else {
			StartCoroutine(Dash ());
		}
	}

	IEnumerator Dash() {
		Vector2 target = Camera.main.ScreenToWorldPoint ((Vector2)Input.mousePosition);
		Vector2 current = rb.transform.position;

		float vy = target.y - current.y;
		float vx = target.x - current.x;
		Vector2 force = new Vector2 (vx, vy);
		force.Normalize ();
		rb.velocity = force * dashForce;
		hasDashed = true;

		for (int i = 0; i < 3; i++) {
			yield return null;
		}

		rb.velocity = rb.velocity / dashFalloff;
	}

	public IEnumerator Boost() {
		DisableControls ();
        StopCoroutine("Dash");
		sr.color = new Color (0, 217, 198, 255);
		rb.gravityScale = 0;
		coll.isTrigger = true;
		hasBoost = true;
		rb.velocity = new Vector2 (0, boostSpeed);
		yield return new WaitForSeconds (boostDuration);
		hasBoost = false;
		coll.isTrigger = false;
		rb.gravityScale = 1;
		sr.color = new Color (0, 255, 0, 255);
		EnableControls ();
	}

	public void DisableControls() {
		canMove = false;
	}

	public void EnableControls() {
		canMove = true;
		hasJumped = false;
		hasDashed = false;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.collider != lastWall || other.gameObject.CompareTag("ResetJump") || other.gameObject.CompareTag("Enemy")) {
			hasDashed = false;
			hasJumped = false;
			if (other.gameObject.CompareTag ("Enemy"))
				Destroy (other.gameObject);
		}
		lastWall = other.collider;
	}
}
