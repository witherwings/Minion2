using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitAction : MonoBehaviour {

	public GameObject[] attacks;
	public string targetsTag;

	void Awake () {
		foreach (var attack in attacks) {
			Instantiate (attack);
			attack.GetComponent<AttackTarget> ().ownerUnit = this.gameObject;
		}
	}

	GameObject findRandomTarget() {
		GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag (targetsTag);

		if (possibleTargets.Length > 0) {
			int targetIndex = Random.Range (0, possibleTargets.Length);
			GameObject target = possibleTargets [targetIndex];

			return target;
		}

		return null;
	}

	public void act() {
		GameObject target = findRandomTarget ();
		int attackType = Random.Range (0, attacks.Length);
		this.attacks [attackType].GetComponent<AttackTarget> ().ownerUnit = this.gameObject;
		this.attacks[attackType].GetComponent<AttackTarget> ().hit (target);
	}
}
