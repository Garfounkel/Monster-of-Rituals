using UnityEngine;
using System.Collections;

public class ControlableBody : MonoBehaviour {

	public float speed;
	public float maxVelocity;

	private Rigidbody2D rb;
	private int direction;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
	}
	
	void Update () 
	{
		if (Input.GetAxis ("Horizontal") > 0) {
			Debug.Log ("right");
			direction = 1;
		} else if (Input.GetAxis ("Horizontal") < 0) {
			Debug.Log ("left");
			direction = -1;
		} else {
			direction = 0;
		}

		if (rb.velocity.magnitude < maxVelocity)
			rb.AddForce (transform.right * direction * speed);
	}
}
