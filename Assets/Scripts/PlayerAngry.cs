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
		switch (currentMood) {
		case Mood.good:
			NewMood (Mood.good, goodMoodSprite, goodMoodSpeed);
			break;
		case Mood.neutral:
			NewMood (Mood.neutral, neutralMoodSprite, neutralMoodSpeed);
			break;
		case Mood.angry:
			NewMood (Mood.angry, angryMoodSprite, angryMoodSpeed);
			break;
		case Mood.veryAngry:
			NewMood (Mood.veryAngry, veryAngryMoodSprite, veryAngryMoodSpeed);
			break;
		}
	}

	private void NewMood(Mood mood, Sprite sprite, float speed)
	{
		previousMood = mood;
		playerRenderer.sprite = sprite;
		cb.m_MaxSpeed = speed;
	}

	public enum Mood {
		good,
		neutral,
		angry,
		veryAngry,
		Count
	}
}

