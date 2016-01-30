using UnityEngine;
using System.Collections;

public class TentaculeOverlap : MonoBehaviour
{

    private SpriteRenderer[] sprites;

	void Start ()
	{
	    sprites = GetComponentsInChildren<SpriteRenderer>();
	}
	
    public void AddSortingOrder(int nb)
    {
        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.sortingOrder += nb;
        }
    }
}
