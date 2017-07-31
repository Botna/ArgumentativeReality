using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class AlternatorOpCodeList : MonoBehaviour, IInputClickHandler {
    SpriteRenderer myRenderer;
    private GameObject AlternatorDot;
   
	// Use this for initialization
	void Start () {
        myRenderer = this.GetComponent<SpriteRenderer>();
        AlternatorDot = GameObject.Find("AlternatorDot");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SimulateClick()
    {
        myRenderer.enabled = !myRenderer.enabled;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
            AlternatorDot.GetComponent<SpriteRenderer>().color = AlternatorDot.GetComponent<ExpandPartInfo>().HighMaintenanceColor;
        this.GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("AlternatorDot").GetComponent<ExpandPartInfo>().OnInputClicked(null);

    }
}
