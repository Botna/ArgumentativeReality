using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class CameraHitbox : MonoBehaviour, IInputClickHandler {

    public CameraManager manager;

    // Use this for initialization
    void Start () {
        if (manager == null)
        {
            Debug.LogError("Please include a Camera Manager.");
        }
    }
	
	// Update is called once per frame
	void Update () {
	}

    public event EventHandler pictureTaken;
    protected virtual void OnPictureTaken()
    {
        if (pictureTaken != null) pictureTaken(this, new EventArgs());
    }

    public bool active
    {
        get
        {
            var collider = gameObject.GetComponent<MeshCollider>();
            bool result = false;
            if (collider != null)
            {
                result = collider.enabled;
            }
            return result;
        }
        set
        {
            var collider = gameObject.GetComponent<MeshCollider>();
            if (collider != null)
            {
                collider.enabled = value;
            }
        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        OnPictureTaken();
    }
}
