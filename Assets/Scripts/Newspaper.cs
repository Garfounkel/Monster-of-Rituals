using UnityEngine;
using System.Collections;

public class Newspaper : InteractableNeed, IPickUpReact {

    public SpriteRenderer spriteRenderer;
    public float ReadingDistanceTreshold = 3;
    public Transform Mouth;
    public Sprite RolledSprite;
    public Sprite OpenSprite;

    private int originalSortingOrder = 0;
    private bool _isReading;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Vector2.Distance(transform.position, Mouth.position) < ReadingDistanceTreshold)
	    {
	        if (!_isReading)
	        {
	            PerformNeed();
	            _isReading = true;
	        }
	    }
	    else
	    {
	        if (_isReading)
	        {
	            StopPerformingNeed();
	            _isReading = false;
	        }
	    }
	}

    public override void PerformNeed()
    {
        base.PerformNeed();
        spriteRenderer.sprite = OpenSprite;
    }

    public override void StopPerformingNeed()
    {
        base.StopPerformingNeed();
        spriteRenderer.sprite = RolledSprite;
    }

    protected override void OnNeedComplete()
    {
        base.OnNeedComplete();
        Debug.Log("Reading complete!");
    }

    public void OnPickUp()
    {
        originalSortingOrder = spriteRenderer.sortingOrder;
        spriteRenderer.sortingOrder = 20;
    }

    public void OnLetGo()
    {
        spriteRenderer.sortingOrder = originalSortingOrder;
    }
}
