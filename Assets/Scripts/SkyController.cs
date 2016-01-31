using UnityEngine;
using System.Collections;

public class SkyController : MonoBehaviour {

	public SpriteRenderer skyRenderer;
	public Color morningColor;
	public Color midDayColor;
	public Color eveningColor;
	public Color nightColor;

	void Update(){
		if (Clock.instance != null){
//			if (Clock.CurrentHour
			skyRenderer.color = Color.blue * (Clock.CurrentHour / 24f); 
//			Debug.Log("COLOR IS " + skyRenderer.color);
		}
	}

}
