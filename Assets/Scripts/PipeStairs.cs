using System;
using System.Collections;
using UnityEngine;

public class PipeStairs : MonoBehaviour
{
    public AudioClip pipeSound;
    public Transform exit;
    public float TargetZ;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        ControlableBody cb = other.GetComponent<ControlableBody>();
        if (cb != null)
        {
            StartCoroutine(Teleportation(cb));
        }
    }

    private IEnumerator Teleportation(ControlableBody cb)
    {
        /*
        while (cb.transform.rotation.z > -90 && cb.transform.rotation.z < 90) 
        {
            cb.transform.Rotate(new Vector3(0, 0, Time.deltaTime * 100));
            yield return null;
        }
        */

        cb.gameObject.SetActive(false);
        // Play sound
        yield return new WaitForSeconds(0.5f);
        cb.gameObject.SetActive(true);
        //float y = cb.transform.position.y;
        float y = exit.position.y;
        cb.transform.position = new Vector2(exit.position.x, y);
    }
}
