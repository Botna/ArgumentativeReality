using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
public class AlternatorStatusToggle : MonoBehaviour, IInputClickHandler  {

	private GameObject AlternatorDot;
	Sprite conditionBadSprite;
	Sprite conditionNeutralSprite;
	bool isBad;

	void Start () {
		AlternatorDot = GameObject.Find ("AlternatorDot");

		isBad = false;
		conditionBadSprite = Resources.Load<Sprite> ("alternatorConditionBad");
		conditionNeutralSprite= Resources.Load<Sprite> ("alternatorCondition@2x");

		this.GetComponent<SpriteRenderer> ().sprite = conditionNeutralSprite;
	}

	public void OnInputClicked(InputClickedEventData eventData){
        //enable the spriterenderer of my child, or tell it to eenable itself,
        this.GetComponentInChildren<AlternatorOpCodeList>().SimulateClick();
		Debug.Log("Inspection status clicked");
        isBad = !isBad;
        if (isBad)
        {
            this.GetComponent<SpriteRenderer>().sprite = conditionBadSprite;
           
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = conditionNeutralSprite;
            
        }


    }
}
