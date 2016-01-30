using UnityEngine;
using System.Collections;

public class PlayerMouth : MonoBehaviour {

	private Clock clock;

	private void Start()
	{
		clock = FindObjectOfType<Clock> ();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Coffee") {
			Debug.Log("STARTED DRINKING");
			other.GetComponent<InteractableNeed>().PerformNeed();
		}
	}

	private void OnTriggerExit2D(Collider2D other){		
		if (other.tag == "Coffee") {
			Debug.Log("STOPPED DRINKING");
			other.GetComponent<InteractableNeed>().StopPerformingNeed();
		}

	}
}
