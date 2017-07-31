using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
public class SelectRedCondition : MonoBehaviour, IInputClickHandler
{
    bool isChecked = false;
    // Use this for initialization
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
        if (isChecked)
        {
            this.GetComponentInParent<ColorSelectionManager>().makeRed();
        }
        else
        {
            this.GetComponentInParent<ColorSelectionManager>().makeNeutral();
        }

    }
}

