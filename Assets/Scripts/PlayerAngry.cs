﻿using UnityEngine;
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

	public void MoreAngry()
	{
		if (currentMood != Mood.veryAngry)
			currentMood++;
	}

	public void LessAngry()
	{
		if (currentMood != Mood.good)
			currentMood--;
	}

	public void UpdateMood ()
	{
		switch (currentMood) {
		case Mood.good:
			NewMood (Mood.good, goodMoodSprite, Color.green, goodMoodSpeed);
			break;
		case Mood.neutral:
			NewMood (Mood.neutral, neutralMoodSprite, Color.grey, neutralMoodSpeed);
			break;
		case Mood.angry:
			NewMood (Mood.angry, angryMoodSprite, Color.yellow, angryMoodSpeed);
			break;
		case Mood.veryAngry:
			NewMood (Mood.veryAngry, veryAngryMoodSprite, Color.red, veryAngryMoodSpeed);
			break;
		}
	}

	private void NewMood(Mood mood, Sprite sprite, Color color, float speed)
	{
		previousMood = mood;
		playerRenderer.sprite = sprite;
		playerRenderer.color = color;
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

