using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class ValveCoverStatusToggle : MonoBehaviour, IInputClickHandler {

	private GameObject ValveCoverDot;

	Sprite conditionGoodSprite;
	Sprite conditionNeutralSprite;
	bool isSelected;

	void Start () {
		ValveCoverDot = GameObject.Find ("ValveCoverDot");

		isSelected = false;
		conditionGoodSprite = Resources.Load<Sprite> ("valveCoverConditionGood@2x");
		conditionNeutralSprite= Resources.Load<Sprite> ("valveCoverCondition@2x");

		this.GetComponent<SpriteRenderer> ().sprite = conditionNeutralSprite;
	}

	public void OnInputClicked(InputClickedEventData eventData){
		Debug.Log("Inspection status clicked");
		isSelected = !isSelected;
		if (isSelected) {
			this.GetComponent<SpriteRenderer> ().sprite = conditionGoodSprite;
			ValveCoverDot.GetComponent<SpriteRenderer>().color = ValveCoverDot.GetComponent<ExpandPartInfo>().PassedColor;
		} else {
			this.GetComponent<SpriteRenderer> ().sprite = conditionNeutralSprite;
			ValveCoverDot.GetComponent<SpriteRenderer>().color = ValveCoverDot.GetComponent<ExpandPartInfo>().SelectedColor;
		}
	}
}
