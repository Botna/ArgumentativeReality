using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateViewer : MonoBehaviour {

    public float speed;

    private bool rotationOn;

    // Update is called once per frame
    void Update () {
        if (rotationOn)
        {
            transform.Rotate(0, speed, 0);
        }
	}

    void StartRotation()
    {
        Debug.Log("what0");
        rotationOn = true;
    }

    void StopRotation()
    {
        rotationOn = false;
    }
}
