using UnityEngine;
using System.Collections;

public class TentaclePickUpTrigger : MonoBehaviour {

	public FixedJoint2D fixedJoint;

	bool mouseIsDown;

	void Start(){
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
		if (mouseIsDown && col.attachedRigidbody != null && fixedJoint.connectedBody == null){
			Debug.Log("TRYING TO PICK UP");
			fixedJoint.connectedBody = col.attachedRigidbody;
			fixedJoint.connectedAnchor = Vector2.zero;
			fixedJoint.enabled = true;
		}
	}
}
