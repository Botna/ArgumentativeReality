using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateBaseOnGaze : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void translateDotsToCurrentPosition()
    {
        var myPos = Camera.main.transform.position;
        transform.position = myPos + Camera.main.transform.forward * .02f + new Vector3(0.0f, 1f);
        transform.rotation = new Quaternion(0.0f, Camera.main.transform.rotation.y, 0.0f, Camera.main.transform.rotation.w);


        GameObject.Find("Gray Dot Container").GetComponent<ShowDotsUnderHood>().showDots();
    }
}
