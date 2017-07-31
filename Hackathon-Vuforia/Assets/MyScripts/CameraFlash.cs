using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFlash : MonoBehaviour {

    SpriteRenderer spriteRenderer
    {
        get
        {
            return GetComponent<SpriteRenderer>(); 
        }
    }
        
    bool animating = false;
    float t = 0.0f;

    public float flashTime = 0.3f;

    float alpha 
    {
        set
        {
            Color color = spriteRenderer.color;
            spriteRenderer.color = new Color(color.r, color.g, color.b, value);
        }
    }

	void Start () {
        alpha = 0.0f;
    }

    void Update () {
        if (spriteRenderer != null && animating)
        {
            float midpoint = flashTime / 2.0f;
            t += Time.deltaTime;
            float a = 0.0f;
            if (t < midpoint)
            {
                a = t / midpoint;
            }
            else if (t < midpoint * 2)
            {
                a = 1.0f - ((t - midpoint) / midpoint);
            }
            else
            {
                animating = false;
            }
            alpha = a;
        }
	}

    public void Flash()
    {
        animating = true;
        t = 0.0f;
    }
}
