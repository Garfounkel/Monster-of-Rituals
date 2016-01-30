using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneAutoLoader : MonoBehaviour {

	public static SceneAutoLoader instance;
	public string[] otherScenes;

	void Start(){
		if (instance != null){
			Destroy(this);
		}
		else{
			instance = this;
			Debug.Log("SETTING INSTANCE!");
		
			for (int i = 0; i < otherScenes.Length; i++){
				if (SceneManager.GetActiveScene().name != otherScenes[i]){
					SceneManager.LoadScene(otherScenes[i], LoadSceneMode.Additive);
				}
			}
		}
	}
}
