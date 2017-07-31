using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class StopTrackingOnLoad : MonoBehaviour {
    AudioSource audioSource = null;
    AudioClip doneTracking = null;
    int threshold = 20;
    int count = 0;
    private MeshRenderer meshRenderer;
    DefaultTrackableEventHandler vuforiaTracker;
    public bool isEnabled = false;
	// Use this for initialization
	void Start () {

        // Add an AudioSource component and set up some defaults
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialize = true;
        audioSource.spatialBlend = 1.0f;
        audioSource.dopplerLevel = 0.0f;
        audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
        audioSource.maxDistance = 20f;
        vuforiaTracker = this.GetComponentInParent<DefaultTrackableEventHandler>();
        // Load the Sphere sounds from the Resources folder
        doneTracking = Resources.Load<AudioClip>("scanCompleteDing");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnabled)
        {
            if (vuforiaTracker.isPresentlyTracking())
            {
                count++;
                if (count > threshold)
                {
                    var trackerInstance = TrackerManager.Instance;
                    if (trackerInstance != null)
                    {
                        var objTracker = trackerInstance.GetTracker<ObjectTracker>();
                        if (objTracker != null)
                        {
                            objTracker.Stop();
                        }
                    }
                    CameraDevice.Instance.Stop();
                    //Disable vuforia for better perf?
                    //int childCount = transform.childCount;
                    //for (int i = 0; i < childCount; i++)
                    //{
                    //    var childObject = transform.GetChild(i);
                        
                    //    var sprite = childObject.GetComponentInChildren<SpriteRenderer>();
                    //    if (sprite != null)
                    //        sprite.enabled = true;
                    //    var collider = childObject.GetComponentInChildren<Collider>();
                    //    collider.enabled = true;

                        
                    //}
                    audioSource.clip = doneTracking;
                    audioSource.Play();
                    GameObject.Find("ListOfOpCodes").GetComponent<SpriteRenderer>().enabled = false ;
                    

                    isEnabled = true;
                }
            }
            else
            {
                count = 0;
            }
        }

    }

    public void resetTracking()
    {
        CameraDevice.Instance.Start();
        if(TrackerManager.Instance != null)
        {
            TrackerManager.Instance.GetTracker<ObjectTracker>().Start();
        }
        
        isEnabled = false;
        count = 0;
    }
}
