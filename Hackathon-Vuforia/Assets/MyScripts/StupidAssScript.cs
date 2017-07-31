using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidAssScript : MonoBehaviour {
   public  bool hasBeenClicked = false;
        SpriteRenderer myRenderer;
	// Use this for initialization
	void Start () {
        myRenderer = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (hasBeenClicked)
            myRenderer.enabled = true;
        else
            myRenderer.enabled = false;
	}
}
