using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class SelectFailureReason : MonoBehaviour, IInputClickHandler {
    public void OnInputClicked(InputClickedEventData eventData)
    {
        var vehicleInfoGO = GameObject.Find("ApptInfo");
        if(vehicleInfoGO != null)
        {
            var script = vehicleInfoGO.GetComponentInChildren<ExpandBasedOnFailedInspection>();
            if(script != null)
            {
                script.addFailedOpcodeFromTire();
                this.GetComponent<StupidAssScript>().hasBeenClicked = false;
                //Now disable my mesh

                this.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
               
    }

    Collider myCollider;
    // Use this for initialization
    void Start()
    {
        myCollider = this.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!myCollider.enabled)
        {
            myCollider.enabled = true;
            Debug.Log("Turned on my collider");
        }
    }
}
