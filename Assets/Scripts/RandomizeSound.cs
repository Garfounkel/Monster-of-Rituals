using UnityEngine;
using System.Collections;

public class RandomizeSound : MonoBehaviour {

	public float pitchVariance = 0.2f;
	public bool playOnAwake = true;

	AudioSource source;
	float lowerPitchBound;
	float higherPitchBound;

	void Start(){
		source = GetComponent<AudioSource>();
		lowerPitchBound = source.pitch - pitchVariance/2f;
		higherPitchBound = source.pitch + pitchVariance/2f;
		if (playOnAwake){
			Play();
		}
	}

	void Update () {
	
	}

	public void Play(){
		source.pitch = Random.Range(lowerPitchBound, higherPitchBound);
		source.Play();
	}
}
