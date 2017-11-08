using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ShowUnitStat : MonoBehaviour {

	[SerializeField]
	protected GameObject unit;

	public Image bar;

	private float maxValue;
	private Vector2 initialScale;

	void Start() {
		maxValue = newStatValue();
		this.initialScale = this.unit.transform.localScale;
	}

	void Update() {
		if (this.unit) {
			float newValue = this.newStatValue ();
			//float newScale = (this.initialScale.x * newValue) / this.maxValue;
			//this.gameObject.transform.localScale = new Vector2(newScale, this.initialScale.y);

			bar.fillAmount = newValue / this.maxValue;
		}
	}

	public void changeUnit(GameObject newUnit) {
		this.unit = newUnit;
		this.Start ();
	}

	abstract protected float newStatValue();
}
