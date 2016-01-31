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
			Color startColor = Color.white;
			Color endColor = Color.black;
			float lerpAmount = 0f;
			if (Clock.CurrentHour >= 0f && Clock.CurrentHour < 6f){
				startColor = nightColor;
				endColor = morningColor;
				lerpAmount = Clock.CurrentHour/6f;
			}
			else if (Clock.CurrentHour >= 6f && Clock.CurrentHour < 12f){
				startColor = morningColor;
				endColor = midDayColor;
				lerpAmount = (Clock.CurrentHour-6f)/6f;
			}
			else if (Clock.CurrentHour >= 12f && Clock.CurrentHour < 18f){
				startColor = midDayColor;
				endColor = eveningColor;
				lerpAmount = (Clock.CurrentHour-12f)/6f;
			}
			else if (Clock.CurrentHour >= 18f && Clock.CurrentHour < 24f){
				startColor = eveningColor;
				endColor = nightColor;
				lerpAmount = (Clock.CurrentHour-18f)/6f;
			}
			skyRenderer.color = Color.Lerp(startColor, endColor, lerpAmount); 
//			Debug.Log("COLOR IS " + skyRenderer.color);
		}
	}

}
