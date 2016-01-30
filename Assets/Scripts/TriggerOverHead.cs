using UnityEngine;
using System.Collections;

public class TriggerOverHead : MonoBehaviour {

	public Sprite image;

	private Sprite previousImage;

	private void OnTriggerEnter2D(Collider2D other){

		ControlableBody cb = other.GetComponent<ControlableBody> ();
		if (cb != null) {
			SpriteRenderer rend = cb.OverHeadSprite;
			previousImage = rend.sprite;
			rend.sprite = image;
		}
	}

	private void OnTriggerExit2D(Collider2D other){

		ControlableBody cb = other.GetComponent<ControlableBody> ();
		if (cb != null) {
			SpriteRenderer rend = cb.OverHeadSprite;
			rend.sprite = previousImage;
		}
	}
}
