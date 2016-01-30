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
		if (other.tag == "Coffe") {
			if (Clock.CurrentHour < clock.coffeTime) {
				// DO COFFE STUFF
			} else {
				// TURN ANGRY 
			}
		}
	}
}
