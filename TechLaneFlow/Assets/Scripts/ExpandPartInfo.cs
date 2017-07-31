using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class ExpandPartInfo : MonoBehaviour, IInputClickHandler {

	GameObject infoContainer;
	public Color HighMaintenanceColor;
	public Color LowMaintenanceColor;
	public Color PassedColor;
	public Color SelectedColor;
	public Color DefaultColor;

	private Color currentColor;

	private bool isSelected;
    public GameObject myPart;
	void Start (){
		//currentColor = gameObject.GetComponent<SpriteRenderer> ().color;
		//currentColor = DefaultColor;

		//statusColors ["Passed"] = Color.green;
		//statusColors ["High Maintenance"] = Color.red;
		//statusColors ["Low Maintenance"] = Color.yellow;
		//statusColors ["Selected"] = Color.blue;
		//statusColors ["Default"] = new Color (255, 255, 255, 153);

		isSelected = false;

		infoContainer = transform.GetChild (0).gameObject;
		infoContainer.SetActive (false);
	}

	public void OnInputClicked(InputClickedEventData eventData){
		infoContainer.SetActive (!infoContainer.activeInHierarchy);

        
        


        if (isSelected && (gameObject.GetComponent<SpriteRenderer> ().color != PassedColor) 
			&& (gameObject.GetComponent<SpriteRenderer> ().color != HighMaintenanceColor)
			&& (gameObject.GetComponent<SpriteRenderer> ().color != LowMaintenanceColor)) 
		{
			gameObject.GetComponent<SpriteRenderer> ().color = DefaultColor;
           
            
		} else if((gameObject.GetComponent<SpriteRenderer> ().color != PassedColor)
			&& (gameObject.GetComponent<SpriteRenderer> ().color != HighMaintenanceColor)
			&& (gameObject.GetComponent<SpriteRenderer> ().color != LowMaintenanceColor))
		{
			Debug.Log ("Changing to selected color");
			gameObject.GetComponent<SpriteRenderer> ().color = SelectedColor;
			
           
        }

        isSelected = !isSelected;
        if (isSelected)
            myPart.GetComponent<ExpandModel>().DisplayPartCommand();
        else
            myPart.GetComponent<ExpandModel>().ResetEngineCommand();


    }
}
