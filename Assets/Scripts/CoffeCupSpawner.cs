using UnityEngine;
using System.Collections;

public class CoffeCupSpawner : MonoBehaviour {

	public GameObject coffeCup;
	public GameObject coffeCupPrefab;

	void Update(){
		if (coffeCup == null){
			coffeCup = (GameObject)Instantiate(coffeCupPrefab, transform.position, transform.rotation);
		}
	}

}
