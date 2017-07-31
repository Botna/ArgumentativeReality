using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTrackingFinished : MonoBehaviour {
    StopTrackingOnLoad tracker;
    SpriteRenderer mySprite;
    MeshRenderer myMesh;
    Collider myCollider;
	// Use this for initialization
	void Start () {
        tracker = GameObject.Find("Holder").GetComponent<StopTrackingOnLoad>();
        mySprite = this.GetComponent<SpriteRenderer>();
        myMesh = this.GetComponent<MeshRenderer>();
        myCollider = this.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		if(tracker.isEnabled)
        {
            //turn on my meshs and sprite renderes
            if (mySprite != null)
                mySprite.enabled = true;


            if (myMesh != null)
                myMesh.enabled = true;
            if(myCollider != null)
                myCollider.enabled = true;
        }
        else
        {
            //turn on my meshs and sprite renderes
            if (mySprite != null)
                mySprite.enabled = false;


            if (myMesh != null)
                myMesh.enabled = false;
            if (myCollider != null)
                myCollider.enabled = false;
        }

        


    }
}
