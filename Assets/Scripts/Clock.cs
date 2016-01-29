using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {

	public Transform clockNeedle;
	public float speed;

	private float hours;

	void Start()
	{
		hours = 0;
	}

	void Update () 
	{
		clockNeedle.RotateAround (transform.position, Vector3.back, Time.deltaTime * speed);
		hours =  12 - ((clockNeedle.eulerAngles.z / 30) % 12);
		Debug.Log ("hour = " + hours);
	}
}
