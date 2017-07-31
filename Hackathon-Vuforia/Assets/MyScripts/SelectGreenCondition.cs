using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class SelectGreenCondition : MonoBehaviour, IInputClickHandler {
    // Use this for initialization
    bool isChecked = false;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void OnInputClicked(InputClickedEventData eventData)
    {
        isChecked = !isChecked;
        if(isChecked)
        {
            this.GetComponentInParent<ColorSelectionManager>().makeGreen();
        }
        else
        {
            this.GetComponentInParent<ColorSelectionManager>().makeNeutral();
        }
        
    }
}
