using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InheritAlphaFromParent : MonoBehaviour {
    public bool isEnabled = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //find the parents
        GazeAngleAlphaManager parentAlphaManager = null;
        Transform currentParent = this.transform.parent;
        int count = 0;
        while (parentAlphaManager == null)
        {
            parentAlphaManager = currentParent.GetComponent<GazeAngleAlphaManager>();
            if(count >= 10)
            {
                throw new System.Exception("Parent not found");
            }
            currentParent = currentParent.parent;
            count++;
        }
        if(count >=2)
        {
            var thing = "";
        }
        var myAlpha = parentAlphaManager.getAlpha();
        var sprite = this.GetComponent<SpriteRenderer>();
        if (myAlpha > 0.0f)
        {
            var oldColor = sprite.color;
            var newColor = new Color(oldColor.r, oldColor.g, oldColor.b, myAlpha);
            sprite.color = newColor;

        }
        else
        {
            var oldColor = sprite.color;
            var newColor = new Color(oldColor.r, oldColor.g, oldColor.b, 0.0f);
            sprite.color = newColor;
        }
        
	}
}
