using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	public AudioSource livingroomMusic;
	public AudioSource kitchenMusic;
	public AudioSource bathroomMusic;
	public AudioSource bedroomMusic;

	void Update () {
		if (ControlableBody.instance != null){
			Transform playerTransform = ControlableBody.instance.transform;
			if (playerTransform.position.x < 0f && playerTransform.position.y < 3f){
				livingroomMusic.volume = 1f;
				kitchenMusic.volume = 0f;
				bathroomMusic.volume = 0f;
				bedroomMusic.volume = 0f;
			}
			else if (playerTransform.position.x > 0f && playerTransform.position.y < 3f){
				livingroomMusic.volume = 0f;
				kitchenMusic.volume = 1f;
				bathroomMusic.volume = 0f;
				bedroomMusic.volume = 0f;
			}
			else if (playerTransform.position.x > 0f && playerTransform.position.y > 3f){
				livingroomMusic.volume = 0f;
				kitchenMusic.volume = 0f;
				bathroomMusic.volume = 1f;
				bedroomMusic.volume = 0f;
			}
			else if (playerTransform.position.x < 0f && playerTransform.position.y > 3f){
				livingroomMusic.volume = 0f;
				kitchenMusic.volume = 0f;
				bathroomMusic.volume = 0f;
				bedroomMusic.volume = 1f;
			}
		}
	}
}
