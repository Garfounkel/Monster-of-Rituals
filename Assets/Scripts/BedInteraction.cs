using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BedInteraction : MonoBehaviour
{

    public FadeScreen fadeScreen;

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Restart());
        }
    }
#endif

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Clock.instance.whiskyDrinked && Clock.CurrentHour > 20 && other.GetComponent<ControlableBody>() != null)
        {
            StartCoroutine(Restart());
        }
    }

    private IEnumerator Restart()
    {
        Debug.Log("Restarting");
        yield return StartCoroutine(fadeScreen.FadeOut());
        SceneManager.LoadScene(0);
    }
}
