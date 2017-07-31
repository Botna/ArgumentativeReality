using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class EnableChildOnClick : MonoBehaviour , IInputClickHandler
{

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnInputClicked(InputClickedEventData eventData)
    {
        var myScript = GetComponentInChildren<StupidAssScript>();
        myScript.hasBeenClicked = !myScript.hasBeenClicked;

    }
}
