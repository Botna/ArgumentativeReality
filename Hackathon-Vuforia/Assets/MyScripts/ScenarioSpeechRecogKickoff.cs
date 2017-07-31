using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;
using HoloToolkit.Unity;

public class ScenarioSpeechRecogKickoff : MonoBehaviour {
    AudioSource audioSource = null;
    AudioClip carHereClip = null;
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

        // Load the Sphere sounds from the Resources folder
        carHereClip = Resources.Load<AudioClip>("CarDing");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BeginScenario()
    {
        //Play the sound and flip the flag of our indicator.
        var dirIndicator = GetComponent<ArrivalDirectionIndicator>();
        dirIndicator.isEnabled = true;
        audioSource.clip = carHereClip;
        audioSource.Play();
    }
}
