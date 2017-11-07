using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTarget : MonoBehaviour {
	
	public GameObject targetEnemyUnitPrefab;

	public void selectEnemyTarget() {
		Debug.Log ("clic bat"); //Para testeos
		GameObject party = GameObject.Find ("Party");
		party.GetComponent<SelectUnit> ().attackEnemyTarget (this.targetEnemyUnitPrefab);
	}
}
