using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {

	public Transform clockNeedle;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		clockNeedle.RotateAround (transform.position, Vector3.right, Time.deltaTime * 5);
	}
}
