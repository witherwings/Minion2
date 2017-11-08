using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTarget : MonoBehaviour {

	public GameObject ownerUnit;
	public string attackAnimation;

	public bool magicAttack;
	public float manaCost;

	public float minAttackMultipplier;
	public float maxAttackMultipplier;
	public float minDefenseMultipplier;
	public float maxDefenseMultipplier;

	public void hit(GameObject target){
		UnitStats ownerSt = this.ownerUnit.GetComponent<UnitStats> ();
		UnitStats targetSt = target.GetComponent<UnitStats> ();
		if (ownerSt.mana >= this.manaCost) {
			float attackMulipplier = (Random.value * (this.maxAttackMultipplier - this.minAttackMultipplier)) + this.minAttackMultipplier;
			float damage = (this.magicAttack) ? (attackMulipplier * ownerSt.magic / 2) : (attackMulipplier * ownerSt.attack / 2);

			float defenseMulipplier = (Random.value * (this.maxDefenseMultipplier - this.minDefenseMultipplier)) + this.minDefenseMultipplier;
			damage = Mathf.Max (0, damage - (defenseMulipplier * targetSt.defense));

			float chanceOfMiss = Random.value;
			if (chanceOfMiss > 0.9 && chanceOfMiss < 1) {
				damage = 0;
			}

			float chanceOfCrit = Random.value;
			if (chanceOfCrit > 0.7 && chanceOfMiss < 0.75) {
				damage = damage * 1.5f;
			}

			this.ownerUnit.GetComponent<Animator> ().Play (this.attackAnimation);

			targetSt.receiveDamage (damage);

			ownerSt.mana -= this.manaCost;
		}
	}
}
