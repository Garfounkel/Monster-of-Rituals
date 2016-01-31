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
			if (fixedJoint.connectedBody != null){
				IPickUpReact pickUpReactor = fixedJoint.connectedBody.gameObject.GetComponent<IPickUpReact>();
				if (pickUpReactor != null){
					pickUpReactor.OnLetGo();
				}
			}
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
			IPickUpReact pickUpReactor = col.attachedRigidbody.gameObject.GetComponent<IPickUpReact>();
			if (pickUpReactor != null){
				pickUpReactor.OnPickUp();
			}
		}
	}
}
