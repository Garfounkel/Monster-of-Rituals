using UnityEngine;
using System.Collections;

public class TentacleTipController : MonoBehaviour {

	public Transform anchorTransform;
	public float maxDistanceFromAnchor = 4f;
	public bool trackMouse = true;
	public Transform customTargetTransform;

	private Rigidbody2D localRigid;

	void Start () {
		localRigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 target; 
		if (trackMouse){
			Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, 0f);
		}
		else{
			target = customTargetTransform.position;
		}
			float currentDistance = Vector3.Distance(anchorTransform.position, target);
			if (currentDistance > maxDistanceFromAnchor){
				Vector3 normalizedDirectionVector = Vector3.Normalize(target - anchorTransform.position);
				target = anchorTransform.position + (normalizedDirectionVector * maxDistanceFromAnchor);
			}
			localRigid.MovePosition(target);

	}
}
