using UnityEngine;
using System.Collections;

public class FadeScreen : MonoBehaviour {

    public float speed;

    private void Start()
    {
        /*
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        Color color = renderer.color;
        color.a = 255;
        renderer.color = color;
        */
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
