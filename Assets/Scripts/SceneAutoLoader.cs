using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneAutoLoader : MonoBehaviour {

	public static SceneAutoLoader instance;
	public string[] otherScenes;
	public GameObject effectBankPrefab;
	public GameObject musicPrefab;

	void Start(){
		if (instance != null){
			Destroy(this);
		}
		else{
			instance = this;
		
			for (int i = 0; i < otherScenes.Length; i++){
				if (SceneManager.GetActiveScene().name != otherScenes[i]){
					SceneManager.LoadScene(otherScenes[i], LoadSceneMode.Additive);
				}
			}
			Instantiate(effectBankPrefab);
			Instantiate(musicPrefab);
		}
	}
}
