using UnityEngine;

public class TentaculeOverlap : MonoBehaviour
{

    private SpriteRenderer[] sprites;

	void Awake ()
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
