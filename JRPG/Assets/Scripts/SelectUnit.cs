using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectUnit : MonoBehaviour {

	private GameObject currentUnit;
	public GameObject actionsMenu, enemyUnitsMenu;

	void Awake() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		if (scene.name == "Battle") {
			this.actionsMenu = GameObject.Find ("Actions");
			this.enemyUnitsMenu = GameObject.Find ("EnemyUnits");
		}
	}

	public void selectCurrentUnit(GameObject unit) {
		this.currentUnit = unit;
		Debug.Log ("set");
		Debug.Log (currentUnit.name);
		//this.actionsMenu.SetActive (true);
		this.currentUnit.GetComponent<PlayerUnitAction> ().updateHUD ();
	}

	public void selectAttack(bool physical) {
		this.currentUnit.GetComponent<PlayerUnitAction> ().selectAttack (physical);

		//this.actionsMenu.SetActive (false);
		//this.enemyUnitsMenu.SetActive (true);
	}

	public void attackEnemyTarget(GameObject target) {
		//this.actionsMenu.SetActive (false);
		//this.enemyUnitsMenu.SetActive (false);

		this.currentUnit.GetComponent<PlayerUnitAction>().act (target);
		GameObject manager = GameObject.Find ("GameManager") as GameObject;
		manager.GetComponent<TurnBattle> ().nextTurn ();
	}
}

