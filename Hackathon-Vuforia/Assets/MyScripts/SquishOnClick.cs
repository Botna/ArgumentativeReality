using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class SquishOnClick : MonoBehaviour, IInputClickHandler{
    bool isSelected = false;
    float initialZVal = 0.0f;
    public void OnInputClicked(InputClickedEventData eventData)
    {
        var thing = "";
        thing += " ";
       //if(!isSelected)
       // {
       //     transform.localPosition -= new Vector3(0.0f, 0.5f,.0f);
       // }
       //else
       // {
       //     transform.localPosition += new Vector3(0.0f, 0.5f, .0f);
       // }
       // isSelected = !isSelected;
    }

    // Use this for initialization
    void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
