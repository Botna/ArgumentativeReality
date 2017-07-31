using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class GazeAngleAlphaManager : MonoBehaviour
{
    float count = 0.01f;
    private MeshRenderer mesh;
    private int maxViewingAngle = 75;
    private int solidViewingAngle = 0;
    private float currentAlpha = 0.0f;
    // Use this for initialization
    void Start()
    {
        mesh = this.gameObject.GetComponentInChildren<MeshRenderer>();
    }
    public float getAlpha()
    {
        return currentAlpha;
    }

    // Update is called once per frame
    void Update()
    {
            //transform.Rotate(0.0f, 0.5f, 0.0f);
            var gazeDirection = Camera.main.transform;
            Vector3 targetDir = gazeDirection.position - transform.position;
            float angle = Vector3.Angle(targetDir, transform.right);
            float alpha = 0.0f;
            if (angle < maxViewingAngle)
            {
                int childCount = transform.childCount;
                for (int i = 0; i < childCount; i++)
                {
                    var childObject = transform.GetChild(i);
                    var sprite = childObject.GetComponentInChildren<SpriteRenderer>();
                    
                    var oldColor = sprite.color;
                    alpha = (maxViewingAngle - angle) / maxViewingAngle;
                    alpha = Math.Min(1.0f, alpha * 2);
                    alpha = (float)Math.Pow(alpha, 5);
                    currentAlpha = alpha;
                    //var newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alpha);
                    //mesh.material.color = newColor;

                }
            }
            else
            {
            currentAlpha = 0.0f;
            }
        }
}
