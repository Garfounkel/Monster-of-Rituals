using UnityEngine;
using System.Collections;

public class EffectBank : MonoBehaviour {

	public static EffectBank instance;

	void Awake(){
		instance = this;
	}

	public GameObject coffeSplashPrefab;

	public static void SplashCoffee (Vector3 position){
		GameObject coffeSplash = (GameObject)Instantiate(instance.coffeSplashPrefab, position, Quaternion.identity);
		SelfDestruct destructScript = coffeSplash.AddComponent<SelfDestruct>();
		destructScript.liveTime = 2f;
	}

}
