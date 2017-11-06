using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCallback : MonoBehaviour {

	public bool physical;

	void Start () {
		this.gameObject.GetComponent<Button> ().onClick.AddListener (() => addCallback());
	}

	private void addCallback() {
		Debug.Log ("clic att"); //Para testeos
		GameObject playerParty = GameObject.Find ("Party");s
		playerParty.GetComponent<SelectUnit> ().selectAttack (this.physical);
	}

}
