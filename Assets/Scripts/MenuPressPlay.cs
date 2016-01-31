using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPressPlay : MonoBehaviour {

	public GameObject sceneLoader;
	public GameObject[] bullshit;

	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.Return))
	    {
			SceneManager.LoadScene(1);
//			sceneLoader.SetActive(true);
//			for (int i = 0; i < bullshit.Length; i++){
//				Destroy(bullshit[i]);
//			}
//			Destroy(gameObject);
	    }

	}
}
