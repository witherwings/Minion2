using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnBattle : MonoBehaviour {

	private List<UnitStats> unitsStats;
	public GameObject winImage;
	public GameObject loseImage;
	private int tmpcount;

	private GameObject party;
	public GameObject actionsMenu;
	public GameObject enemyUnitsMenu;

	void Start() {
		tmpcount = 0;
		party = GameObject.Find ("Party");
		unitsStats = new List<UnitStats> ();
		GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
		foreach (GameObject playerUnit in playerUnits) {
			UnitStats currentUnitStats = playerUnit.GetComponent<UnitStats> ();
			currentUnitStats.calculateNextActTurn (0);
			unitsStats.Add (currentUnitStats);
		}
		GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
		foreach (GameObject enemyUnit in enemyUnits) {
			UnitStats currentUnitStats = enemyUnit.GetComponent<UnitStats> ();
			currentUnitStats.calculateNextActTurn (0);
			unitsStats.Add (currentUnitStats);
		}
		unitsStats.Sort ();

		this.actionsMenu.SetActive (true);
		this.enemyUnitsMenu.SetActive (true);
		this.party.SetActive (true);

		this.nextTurn ();
	}

	public void nextTurn() {
		if (tmpcount < 1000) {
			UnitStats currentUnitStats = unitsStats [0];
			unitsStats.Remove (currentUnitStats);

			if (!currentUnitStats.isDead ()) {
				GameObject currentUnit = currentUnitStats.gameObject;

				currentUnitStats.calculateNextActTurn (currentUnitStats.nextActTurn);
				unitsStats.Add (currentUnitStats);
				//unitsStats.Sort ();

				if (currentUnit.tag == "PlayerUnit") {
					Debug.Log ("player");
					this.party.GetComponent<SelectUnit> ().selectCurrentUnit (currentUnit.gameObject);
					tmpcount++;
				} else {
					Debug.Log ("enemy");
					currentUnit.GetComponent<EnemyUnitAction> ().act ();
					StartCoroutine (PrepareNextTurn());
					tmpcount++;
				}
			} else {
				unitsStats.Remove (currentUnitStats);
				StartCoroutine (PrepareNextTurn ());
			}


		}
	}

	public IEnumerator PrepareNextTurn(){
		GameObject[] remainingEnemyUnits = GameObject.FindGameObjectsWithTag ("EnemyUnit");
		if (remainingEnemyUnits.Length == 0) {
			winImage.SetActive (true);
		}

		GameObject[] remainingPlayerUnits = GameObject.FindGameObjectsWithTag ("PlayerUnit");
		if (remainingPlayerUnits.Length == 0) {
			loseImage.SetActive (true);
		}

		yield return new WaitForSeconds (1.5f);

		this.nextTurn ();
	}
}
