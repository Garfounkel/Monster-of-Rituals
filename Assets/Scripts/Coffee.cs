using UnityEngine;
using System.Collections;

public class Coffee : InteractableNeed {

	public AudioSource slurpSound;

	private bool firstCollision = true;

	protected override void OnNeedPerformed(){
		if (!slurpSound.isPlaying){
			slurpSound.Play();
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (firstCollision){
			firstCollision = false;
			return;
		}
		EffectBank.SplashCoffee(transform.position + (-transform.up * 0.5f));
		Destroy(gameObject);
	}

}
