using UnityEngine;
using UnityEngine.UI;

public class CreateEnemyUnitMenu : MonoBehaviour {

	public GameObject targetEnemyUnitPrefab;
	public Sprite menuItemSprite;
	public Vector2 initialPosition, itemDimensions;
	public KillEnemy killEnemyScript;

	void Awake () {
		GameObject enemyUnitsMenu = GameObject.Find ("EnemyUnits");

		GameObject[] existingItems = GameObject.FindGameObjectsWithTag ("TargetEnemy");
		Vector2 nextPosition = new Vector2 (this.initialPosition.x + (existingItems.Length * this.itemDimensions.x), this.initialPosition.y);

		GameObject targetEnemyUnit = Instantiate (this.targetEnemyUnitPrefab, enemyUnitsMenu.transform) as GameObject;
		targetEnemyUnit.name = "Target" + this.gameObject.name;
		targetEnemyUnit.transform.localPosition = nextPosition;
		targetEnemyUnit.transform.localScale = new Vector2 (0.7f, 0.7f);
		targetEnemyUnit.GetComponent<Button> ().onClick.AddListener (() => selectEnemyTarget());
		targetEnemyUnit.GetComponent<Image> ().sprite = this.menuItemSprite;

		killEnemyScript.menuItem = targetEnemyUnit;
	}

	public void selectEnemyTarget() {
		Debug.Log ("clic bat"); //Para testeos
		GameObject party = GameObject.Find ("Party");
		//party.GetComponent<SelectUnit> ().attackEnemyTarget (this.gameObject);
	}

}
