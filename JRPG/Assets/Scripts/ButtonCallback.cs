using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCallback : MonoBehaviour {

	public bool physical;
	public bool special;

	void Start () {
		this.gameObject.GetComponent<Button> ().onClick.AddListener (() => addCallback());
	}

	private void addCallback() {
		GameObject playerParty = GameObject.Find ("Party");
		if (special) {
			playerParty.GetComponent<SelectUnit> ().selectSpecial ();
		} else {
			playerParty.GetComponent<SelectUnit> ().selectAttack (this.physical);
		}
	}

}
