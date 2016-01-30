using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public static CameraController instance;
	Transform playerTransform;

	// Use this for initialization
	void Start () {
		if (instance != null){
			Destroy(gameObject);
		}
		instance = this;
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update(){
		if (playerTransform != null){
			transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
		}
	}

}
