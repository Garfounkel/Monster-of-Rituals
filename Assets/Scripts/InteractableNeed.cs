using UnityEngine;
using System.Collections;

public class InteractableNeed : MonoBehaviour {

	public NeedType needType;
	public float needTime = 4f;
	public float effectTriggerInterval = 0.5f;

	bool isComplete = false;
	private float waitStartTime = 0f;

	public virtual void PerformNeed(){
		if (!isComplete){
			waitStartTime = Time.time;
			StartCoroutine("WaitForNeedComplete");
			StartCoroutine("PerformNeedLoop");
		}
	}

	protected virtual void OnNeedComplete(){
		isComplete = true;
        Debug.Log("OnNeedComplete(); " + needType);
		Clock.ReportNeedComplete(needType);
	}

	public virtual void StopPerformingNeed() {
		if (!isComplete){
			needTime = needTime - (Time.time - waitStartTime);
			Debug.Log("PREMATURE STOP, THERE IS " + needTime + " SECONDS LEFT");
			StopCoroutine("WaitForNeedComplete");
			StopCoroutine("PerformNeedLoop");
		}
	}

	IEnumerator WaitForNeedComplete(){
		yield return new WaitForSeconds(needTime);
		StopCoroutine("PerformNeedLoop");
		OnNeedComplete();
	}

	IEnumerator PerformNeedLoop(){
		while (true){
			PerformingNeedEffect();
			yield return new WaitForSeconds(effectTriggerInterval);
		}
	}

	//This is called every 'effectTriggerInterval' seconds
	protected virtual void PerformingNeedEffect(){

	}

}
