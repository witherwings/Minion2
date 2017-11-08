using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUnitAction : MonoBehaviour {

	public GameObject physicalAttack;
	public GameObject magicalAttack;
	public GameObject specialAttack;
	public Sprite faceSprite;

	private GameObject currentAttack;

	void Awake () {
		this.physicalAttack = Instantiate (this.physicalAttack, this.transform) as GameObject;
		this.magicalAttack = Instantiate (this.magicalAttack, this.transform) as GameObject;
		this.specialAttack = Instantiate (this.specialAttack, this.transform) as GameObject;

		this.physicalAttack.GetComponent<AttackTarget> ().ownerUnit = this.gameObject;
		this.magicalAttack.GetComponent<AttackTarget> ().ownerUnit = this.gameObject;
		this.specialAttack.GetComponent<AttackTarget> ().ownerUnit = this.gameObject;

		this.currentAttack = this.physicalAttack;
	}

	public void act(GameObject target) {
		this.currentAttack.GetComponent<AttackTarget> ().hit (target);
	}

	public void selectAttack(bool physical) {
		this.currentAttack = (physical) ? this.physicalAttack : this.magicalAttack;
	}

	public void selectSpecial(){
		this.currentAttack = this.specialAttack;
	}

	public void updateHUD() {
		GameObject playerUnitFace = GameObject.Find ("PlayerFaceset") as GameObject;
		playerUnitFace.GetComponent<Image> ().sprite = this.faceSprite;

		GameObject playerUnitHealthBar = GameObject.Find ("Healthbar") as GameObject;
		playerUnitHealthBar.GetComponent<ShowUnitHealth> ().changeUnit (this.gameObject);

		GameObject playerUnitManaBar = GameObject.Find ("Manabar") as GameObject;
		playerUnitManaBar.GetComponent<ShowUnitMana> ().changeUnit (this.gameObject);
	}
}
