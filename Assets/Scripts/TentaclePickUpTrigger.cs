using UnityEngine;
using System.Collections;

public class TentaclePickUpTrigger : MonoBehaviour {

	public FixedJoint2D fixedJoint;

	TentacleTipController controller;
	bool mouseIsDown;

	void Start(){
		controller = GetComponent<TentacleTipController>();
		fixedJoint.enabled = false;
	}

	void Update(){		
		if (!Input.GetMouseButton(0) && mouseIsDown){
			fixedJoint.connectedBody = null;
			fixedJoint.enabled = false;
		}
		mouseIsDown = Input.GetMouseButton(0);
	}

	void OnTriggerStay2D(Collider2D col){
		if (mouseIsDown && controller.trackMouse && col.attachedRigidbody != null && fixedJoint.connectedBody == null && col.gameObject.tag != "Player"){
			fixedJoint.connectedBody = col.attachedRigidbody;
			fixedJoint.connectedAnchor = Vector2.zero;
			fixedJoint.enabled = true;
		}
	}
}
