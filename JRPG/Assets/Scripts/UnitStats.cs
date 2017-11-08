using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UnitStats : MonoBehaviour, IComparable {

	public float health;
	public float mana;
	public float attack;
	public float magic;
	public float defense;
	public float speed;

	public Animator animator;
	public GameObject damageTextPrefab;
	public Vector3 damageTextPosition;

	public int nextActTurn;
	private bool dead = false;

	public void calculateNextActTurn(int currentTurn){
		this.nextActTurn = currentTurn + (int)Mathf.Ceil (100.0f / this.speed);
	}

	public int CompareTo(object stats){
		return nextActTurn.CompareTo (((UnitStats)stats).nextActTurn);	
	}

	public bool isDead(){
		return this.dead;
	}

	public void receiveDamage(float damage) {
		float roundD = (float)Math.Round (damage, 2);
		this.health -= roundD;
		animator.Play ("Hit");

		GameObject HUDCanvas = GameObject.Find ("HUD");
		GameObject damageText = Instantiate (this.damageTextPrefab, HUDCanvas.transform) as GameObject;
		damageText.GetComponent<Text> ().color = Color.green;
		damageText.GetComponent<Text> ().text = "" + roundD;

		if (roundD >= 75) {
			damageText.GetComponent<Text> ().color = Color.red;
		}

		if (roundD >= 50 && roundD < 75) {
			damageText.GetComponent<Text> ().color = Color.blue;
		}

		if (roundD == 0) {
			damageText.GetComponent<Text> ().color = Color.grey;
			damageText.GetComponent<Text> ().text = "Miss";
		} 

		damageText.transform.position = this.damageTextPosition;
		//damageText.transform.localScale = new Vector2 (1.0f, 1.0f);

		if (this.health <= 0) {
			this.dead = true;
			this.gameObject.tag = "DeadUnit";
			Destroy (this.gameObject);
		}

		StartCoroutine (DestroyDamageText (damageText));
	}

	IEnumerator DestroyDamageText (GameObject dmg){
		yield return new WaitForSeconds (1.5f);
		Destroy (dmg);
	}
}
