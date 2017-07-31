using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class Border : MonoBehaviour, IFocusable {
    public void OnFocusEnter()
    {
        Debug.Log("wut");
        foreach (Renderer thing in gameObject.GetComponentsInChildren<Renderer>())
        {
            foreach (Material material in thing.materials)
            {
                material.shader = Shader.Find("Custom/Outline");
            }
        }
        
    }

    public void OnFocusExit()
    {
        foreach (Renderer thing in gameObject.GetComponentsInChildren<Renderer>())
        {
            foreach (Material material in thing.materials)
            {
                material.shader = Shader.Find("Diffuse");
            }
        }
    }
}
