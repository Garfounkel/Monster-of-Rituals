using UnityEngine;
using System.Collections;

public class Coffee : InteractableNeed, IPickUpReact {

	public RandomizeSound slurpSound;
	public SpriteRenderer spriteRenderer;

	private bool firstCollision = true;
	private int originalSortingOrder = 0;

	protected override void OnNeedComplete(){
		base.OnNeedComplete();
	}

	protected override void PerformingNeedEffect(){
		slurpSound.Play();
	}

	void OnCollisionEnter2D(Collision2D col){
		if (firstCollision){
			firstCollision = false;
			return;
		}
		EffectBank.SplashCoffee(transform.position + (-transform.up * 0.5f));
		Destroy(gameObject);
	}

	public void OnPickUp(){
		originalSortingOrder = spriteRenderer.sortingOrder;
		spriteRenderer.sortingOrder = 20;			
	}

	public void OnLetGo(){
		spriteRenderer.sortingOrder = originalSortingOrder;
	}

}
