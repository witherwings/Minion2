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

		GameObject damageText = Instantiate (this.damageTextPrefab) as GameObject;
		damageText.GetComponent<Text> ().text = "" + roundD;
		damageText.transform.position = this.damageTextPosition;
		//damageText.transform.localScale = new Vector2 (1.0f, 1.0f);

		if (this.health <= 0) {
			this.dead = true;
			this.gameObject.tag = "DeadUnit";
			Destroy (this.gameObject);
		}

	}
}
