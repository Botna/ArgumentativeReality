using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public TextMesh picturesTakenCount;
    public AudioSource cameraSoundSource;
    public GameObject cursor;
    public CameraFlash flash;
    public CameraHitbox hitbox;
    public GameObject frame;

    public bool on
    {
        get { return hitbox.active;  }
        set
        {
            hitbox.active = value;
            cursor.SetActive(!value);
            frame.SetActive(value);
        }
    }

    int count
    {
        get
        {
            int result = 0;
            int.TryParse(picturesTakenCount.text, out result);
            return result;
        }
        set
        {
            picturesTakenCount.text = value.ToString();
        }
    }

	// Use this for initialization
	void Start () {
		if (picturesTakenCount == null)
        {
            Debug.LogError("Pictures Taken Count text mesh must be provided");
        }
        if (cursor == null)
        {
            Debug.LogError("Cursor must be provided");
        }
        if (flash == null)
        {
            Debug.LogError("Flash must be provided");
        }
        if (cameraSoundSource == null)
        {
            Debug.LogError("Camera Sound Source must be provided");
        }
        if (hitbox == null)
        {
            Debug.LogError("Hitbox must be provided");
        }
        hitbox.pictureTaken += Hitbox_pictureTaken;
        on = false;
    }

    private void Hitbox_pictureTaken(object sender, EventArgs e)
    {
        if (on) TakePicture();
    }

    // Update is called once per frame
    void Update () {
		
	}


    public void TurnOnCamera()
    {
        on = true;
    }

    public void TurnOffCamera()
    {
        on = false;
    }

    public void TakePicture()
    {
        count++;
        cameraSoundSource.Play();
        flash.Flash();
    }
}
