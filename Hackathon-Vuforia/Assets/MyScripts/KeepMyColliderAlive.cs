using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMyColliderAlive : MonoBehaviour {

    private Collider mycollider;
	// Use this for initialization
	void Start () {

        mycollider = this.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
        mycollider.enabled = true;
	}
}
