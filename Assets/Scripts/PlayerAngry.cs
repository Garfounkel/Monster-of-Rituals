using UnityEngine;
using System.Collections;

public class PlayerAngry : MonoBehaviour {

	public SpriteRenderer playerRenderer;
	public Sprite goodMoodSprite;
	public Sprite neutralMoodSprite;
	public Sprite angryMoodSprite;
	public Sprite veryAngryMoodSprite;

	public float goodMoodSpeed;
	public float neutralMoodSpeed;
	public float angryMoodSpeed;
	public float veryAngryMoodSpeed;

	public static Mood currentMood;
	private Mood previousMood;

	private ControlableBody cb;

	void Start () {
		cb = GetComponent<ControlableBody> ();
		currentMood = Mood.good;
		previousMood = currentMood;
		UpdateMood ();
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.B)) {
			MoreAngry ();
		}
		if (Input.GetKeyDown (KeyCode.N)) {
			LessAngry ();
		}

		if (previousMood != currentMood) {
			UpdateMood ();
		}
	}

	public static void MoreAngry()
	{
		if (currentMood != Mood.veryAngry)
			currentMood++;
	}

	public static void LessAngry()
	{
		if (currentMood != Mood.good)
			currentMood--;
	}

	public void UpdateMood ()
	{
        Debug.Log("Changing mood for " + currentMood);
	    switch (currentMood)
	    {
	        case Mood.good:
	            NewMood(Mood.good, goodMoodSprite, goodMoodSpeed);
                StopAllCoroutines();
                break;
	        case Mood.neutral:
	            NewMood(Mood.neutral, neutralMoodSprite, neutralMoodSpeed);
                StopAllCoroutines();
                break;
	        case Mood.angry:
	            NewMood(Mood.angry, angryMoodSprite, angryMoodSpeed);
                StopAllCoroutines();
                StartCoroutine(Jitter(0.05f, 0.1f));
	            break;
	        case Mood.veryAngry:
	            NewMood(Mood.veryAngry, veryAngryMoodSprite, veryAngryMoodSpeed);
                StopAllCoroutines();
                StartCoroutine(Jitter(0.1f, 0.1f));
	            break;
	    }
	}

	private void NewMood(Mood mood, Sprite sprite, float speed)
	{
		previousMood = mood;
		playerRenderer.sprite = sprite;
		cb.m_MaxSpeed = speed;
	}

    private IEnumerator Jitter(float power, float speed)
    {
        Vector3 prevPos;
        while (true)
        {
            prevPos = playerRenderer.transform.position;
            playerRenderer.transform.position += new Vector3(power * RandomDir(), power * RandomDir());
            yield return new WaitForSeconds(speed);
            playerRenderer.transform.position -= new Vector3(power * RandomDir(), power * RandomDir());
            yield return new WaitForSeconds(speed);
            playerRenderer.transform.position = prevPos;
        }
    }

    private float RandomDir()
    {
        if (Random.value < 0.5f)
            return -1;
        else
            return 1;
    }

	public enum Mood {
		good,
		neutral,
		angry,
		veryAngry,
		Count
	}
}

