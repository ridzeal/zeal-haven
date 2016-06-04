using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {

	public UnityEngine.UI.Text gpcDisplay;
	public UnityEngine.UI.Text goldDisplay;
	public float gold = 0.00f;
	public int goldPerClick = 1;

	void Update() {
		goldDisplay.text = "Gold: " + CurrencyConverter.Instance.GetCurrencyIntoString(gold, false, false);
		gpcDisplay.text = CurrencyConverter.Instance.GetCurrencyIntoString(goldPerClick, false, true);
	}

	public void Clicked() {
		gold += goldPerClick;
	}

}
