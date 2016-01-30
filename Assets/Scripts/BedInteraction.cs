using UnityEngine;
using System.Collections;

public class BedInteraction : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Clock.instance.wiskyDrinked && Clock.CurrentHour > 20 && other.GetComponent<ControlableBody>() != null)
        {
            Debug.Log("it's working");
        }
    }
}
