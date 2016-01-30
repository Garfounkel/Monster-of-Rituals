using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

	public float liveTime = 4f;

	public void Start(){
		StartCoroutine(DieAfterSeconds());
	}

	IEnumerator DieAfterSeconds(){
		yield return new WaitForSeconds(liveTime);
		Destroy(gameObject);
	}

}
