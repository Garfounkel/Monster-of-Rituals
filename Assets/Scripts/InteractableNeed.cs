using UnityEngine;
using System.Collections;

public class InteractableNeed : MonoBehaviour {

	public NeedType needType;
	public float needTime = 4f;
	public float effectTriggerInterval;

	public virtual void PerformNeed(){
		StartCoroutine("WaitForNeedComplete");
		StartCoroutine("PerformNeedLoop");
	}

	protected virtual void OnNeedComplete(){
		Clock.ReportNeedComplete(needType);
	}

	public virtual void StopPerformingNeed() {
		StopCoroutine("WaitForNeedComplete");
		StopCoroutine("PerformNeedLoop");
	}

	IEnumerator WaitForNeedComplete(){
		yield return new WaitForSeconds(needTime);
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
