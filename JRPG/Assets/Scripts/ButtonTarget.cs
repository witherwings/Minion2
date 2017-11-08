using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTarget : MonoBehaviour {
	
	public GameObject targetEnemyUnitPrefab;

	void Update(){
		if (targetEnemyUnitPrefab.CompareTag ("DeadUnit")) {
			Destroy (this.gameObject);
		}
	}

	public void selectEnemyTarget() {
		GameObject party = GameObject.Find ("Party");
		party.GetComponent<SelectUnit> ().attackEnemyTarget (this.targetEnemyUnitPrefab);
	}
}
