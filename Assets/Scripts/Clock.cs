using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {

	public float coffeeTime;

	public Transform clockNeedle;
	public float speed;

	public static float CurrentHour;


	void Start()
	{
		CurrentHour = 0;
	}

	void Update () 
	{
		clockNeedle.RotateAround (transform.position, Vector3.back, Time.deltaTime * speed);
		CurrentHour =  12 - ((clockNeedle.eulerAngles.z / 30) % 12);
		//Debug.Log ("hour = " + hours);
	}
}
