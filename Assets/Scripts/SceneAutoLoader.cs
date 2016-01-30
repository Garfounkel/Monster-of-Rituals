using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneAutoLoader : MonoBehaviour {

	public string[] otherScenes;

	void Awake(){
		for (int i = 0; i < otherScenes.Length; i++){
			if (SceneManager.GetActiveScene().name != otherScenes[i]){
				SceneManager.LoadScene(otherScenes[i], LoadSceneMode.Additive);
			}
		}
	}
}
