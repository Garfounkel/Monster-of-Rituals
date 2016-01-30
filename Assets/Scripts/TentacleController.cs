using UnityEngine;
using System.Collections;

public class TentacleController : MonoBehaviour {

	public TentacleTipController leftTentacle;
	public TentacleTipController rightTentacle;

	public void Update(){
		Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 mouseFlatPosition = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, 0f);
		if (mouseFlatPosition.x > transform.position.x){
			rightTentacle.trackMouse = true;
			leftTentacle.trackMouse = false;
		}
		else{
			rightTentacle.trackMouse = false;
			leftTentacle.trackMouse = true;
		}
	}

}