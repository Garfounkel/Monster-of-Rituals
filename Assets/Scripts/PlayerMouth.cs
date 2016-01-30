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
			if (Clock.CurrentHour < clock.coffeeTime) {
				other.GetComponent<InteractableNeed>().PerformNeed();
			}
		}
	}

	private void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Coffee") {
			if (Clock.CurrentHour < clock.coffeeTime) {
				other.GetComponent<InteractableNeed>().StopPerformingNeed();
			}
		}

	}
}
