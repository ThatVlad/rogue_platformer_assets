using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;

	private Rigidbody2D _rigidBody;
	private float distToGround;
	private Collider2D _collider;

	// Use this for initialization
	void Start () {
		_rigidBody = GetComponent<Rigidbody2D> ();
		_collider = GetComponent<Collider2D> ();
		distToGround = _collider.bounds.extents.y; // distance of character anchor to ground
	}

	// returns true if is standing on "Terrain"-tagged collider
	bool IsGrounded() {
		Collider2D c = Physics2D.Raycast (transform.position - Vector3.up*(distToGround+0.05f), -Vector2.up, distToGround + 0.1f).collider;
		return (c != null && c.CompareTag("Terrain"));
	}

	// Update is called once per frame
	void FixedUpdate () {
		_rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, _rigidBody.velocity.y);
		if(IsGrounded() && Input.GetAxis("Jump") != 0 && _rigidBody.velocity.y > -0.1) _rigidBody.AddForce (Vector2.up * jumpForce);
	}
}