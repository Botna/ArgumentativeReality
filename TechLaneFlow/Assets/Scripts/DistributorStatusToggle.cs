using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class DistributorStatusToggle : MonoBehaviour, IInputClickHandler {

	private GameObject DistributorDot;

	Sprite conditionGoodSprite;
	Sprite conditionNeutralSprite;
	bool isSelected;

	void Start () {

		DistributorDot = GameObject.Find ("DistributorDot");

		isSelected = false;
		conditionGoodSprite = Resources.Load<Sprite> ("distributorConditionGood@2x");
		conditionNeutralSprite= Resources.Load<Sprite> ("distributorCondition@2x");

		this.GetComponent<SpriteRenderer> ().sprite = conditionNeutralSprite;
	}

	public void OnInputClicked(InputClickedEventData eventData){
		Debug.Log("Inspection status clicked");
		isSelected = !isSelected;
		if (isSelected) {
			this.GetComponent<SpriteRenderer> ().sprite = conditionGoodSprite;
			DistributorDot.GetComponent<SpriteRenderer>().color = DistributorDot.GetComponent<ExpandPartInfo>().PassedColor;
		} else {
			this.GetComponent<SpriteRenderer> ().sprite = conditionNeutralSprite;
			DistributorDot.GetComponent<SpriteRenderer>().color = DistributorDot.GetComponent<ExpandPartInfo>().SelectedColor;
		}
	}
}
