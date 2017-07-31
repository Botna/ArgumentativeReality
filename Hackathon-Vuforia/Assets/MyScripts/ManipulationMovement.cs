using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class ManipulationMovement : MonoBehaviour, IManipulationHandler {


    public float manipFactor = 0.0f;
    public void OnManipulationCanceled(ManipulationEventData eventData)
    {
        
    }

    public void OnManipulationCompleted(ManipulationEventData eventData)
    {
       //when manipulation is finished, we need to rotate along only the Y axis so that it faces the viewer. 
    }

    public void OnManipulationStarted(ManipulationEventData eventData)
    {
        
    }

    public void OnManipulationUpdated(ManipulationEventData eventData)
    {
        this.transform.position += eventData.CumulativeDelta * manipFactor;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
