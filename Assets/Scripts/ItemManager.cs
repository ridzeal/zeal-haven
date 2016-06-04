using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

	public UnityEngine.UI.Text itemInfo;
	public Click click;
	public float cost;
	public int tickValue;
	public int count;
	public string itemName;
	private string currentName;
	public Color standard;
	public Color affordable;
	private float baseCost;
	private Slider _slider;

	void Start() {
		baseCost = cost;
		currentName = itemName;
		_slider = GetComponentInChildren<Slider> ();
	}

	void Update() {
		currentName = itemName + " (" + count + ")";
		itemInfo.text = currentName + "\nCost: " + cost + "\nGold: " + tickValue + "/s";

		_slider.value = click.gold / cost * _slider.maxValue;
		if (_slider.value >= _slider.maxValue) {
			GetComponent<Image> ().color = affordable;
			_slider.enabled = false;
		} else {
			GetComponent<Image> ().color = standard;
			_slider.enabled = true;
		}
	}

	public void PurchasedItem() {
		if (click.gold >= cost) {
			click.gold -= cost;
			count += 1;
			cost = Mathf.Round(baseCost * Mathf.Pow(1.15f, count));
		}
	}

}
