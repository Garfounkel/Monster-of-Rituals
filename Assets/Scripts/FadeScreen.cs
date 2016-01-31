using UnityEngine;
using System.Collections;

public class FadeScreen : MonoBehaviour {

    private void Start()
    {
        StartCoroutine(FadeOut(0.1f));
    }

    private IEnumerator FadeIn(float coef)
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        while (renderer.color.a != 0)
        {
            Color color = renderer.color;
            color.a -= coef * Time.deltaTime;
            renderer.color = color;
            yield return null;
        }
    }

    private IEnumerator FadeOut(float coef)
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        while (renderer.color.a != 255)
        {
            Color color = renderer.color;
            color.a += coef * Time.deltaTime;
            renderer.color = color;
            yield return null;
        }
    }
}
