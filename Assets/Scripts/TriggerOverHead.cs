using UnityEngine;
using System.Collections;

public class TriggerOverHead : MonoBehaviour {

	public Sprite image;
    public bool fliped;

	private Sprite previousImage;



	private void OnTriggerEnter2D(Collider2D other){

		ControlableBody cb = other.GetComponent<ControlableBody> ();
		if (cb != null) {
			SpriteRenderer rend = cb.OverHeadSprite;
			previousImage = rend.sprite;
			rend.sprite = image;
		    if (fliped)
		    {
		        rend.flipX = true;
		    }
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
