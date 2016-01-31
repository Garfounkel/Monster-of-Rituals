using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPressPlay : MonoBehaviour {
	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.Return))
	    {
	        SceneManager.LoadScene(1);
	    }
	}
}
