using UnityEngine;
using System.Collections;

public class FadeScreen : MonoBehaviour {

    public float speed;

    private void Awake()
    {
        /*
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        Color color = renderer.color;
        color.a = 255;
        renderer.color = color;
        */
		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1f); 

	}
	private void Start(){
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        while (renderer.color.a > 0)
        {
            Color color = renderer.color;
            color.a -= speed * Time.deltaTime;
            renderer.color = color;
            yield return null;
        }
    }

    public IEnumerator FadeOut()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        while (renderer.color.a < 1)
        {
            Color color = renderer.color;
            color.a += speed * Time.deltaTime;
            renderer.color = color;
            yield return null;
        }
    }
}
