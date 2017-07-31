using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using System;
using UnityEngine.Events;

public class ExpandModel : MonoBehaviour
{
    // We are using a different model for the expanded view.  Set it here so we can swap it out when we expand.
    [Tooltip("Game object for the exploded model.")]
    public GameObject ExpandedModel;

    // Vector measuring offset of this object with the base reference, component_15_1
    public Vector3 VectorDiff;

    // speed of rotation in angles per frame
    public float speed;

    //public GameObject Manager;

    private float timeToTargetPosition = 0.8f;
    private float timeToDefaultPosition = 0.8f;

    private float progress;

    private Vector3 defaultPosition;

    private Coroutine coroutine;

    private GameObject Manager;

    private bool rotationStarted;

    private Transform originalParent;

    private Vector3 defaultRotation;

    void Start()
    {
        Manager = GameObject.Find("Managers");
        rotationStarted = false;
        originalParent = GameObject.Find("EngineComplete").transform;
        Debug.Log(progress + "dog");
        defaultRotation = GameObject.Find("Part Viewer").transform.eulerAngles;

    }

    public void ExpandEngineCommand()
    {
        Debug.Log(GameObject.Find("Managers").GetComponent<SpeechInputHandler>().Keywords[3].Response);
        Debug.Log("Expanding Engine...");
        defaultPosition = transform.position;

        GameObject.Find("Managers").GetComponent<SpeechInputHandler>().Keywords[3].Response.Invoke();
        StopCurrentCoroutineIfActive();

        gameObject.SetActive(true);
        coroutine = StartCoroutine(CountProgress(timeToTargetPosition));
    }

    public void DisplayPartCommand()
    {

        transform.SetParent(GameObject.Find("Part Position").transform);
        defaultPosition = GameObject.Find("EngineComplete").transform.position;
        transform.eulerAngles = transform.parent.GetChild(0).transform.eulerAngles;

        GameObject.Find("Managers").GetComponent<SpeechInputHandler>().Keywords[3].Response.Invoke();
        StopCurrentCoroutineIfActive();

        gameObject.SetActive(true);

        coroutine = StartCoroutine(MoveToDisplay(timeToTargetPosition));
    }

    public void ResetEngineCommand()
    {
        Debug.Log("Resetting Engine...");
        StopCurrentCoroutineIfActive();
        GameObject.Find("Part Viewer").transform.eulerAngles = new Vector3(0, 0, 0);

        if (gameObject.transform.position == ExpandedModel.transform.position) {
            coroutine = StartCoroutine(CountProgress(timeToDefaultPosition * -1));
        }

        if (transform.parent == GameObject.Find("Part Position").transform)
        {
            Debug.Log("werw");
            coroutine = StartCoroutine(MoveToDisplay(timeToDefaultPosition * -1));
        }
    }

    private void StopCurrentCoroutineIfActive()
    {
        if (progress != 0 && progress != 1 && coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }

    IEnumerator MoveToDisplay(float time)
    {
        Vector3 targetPosition = transform.parent.GetChild(0).position;


        while (progress >= 0 && progress <= 1)
        {
            float increment = Time.deltaTime / time;
            progress += increment;
            transform.position = Vector3.Lerp(GameObject.Find("EngineComplete").transform.position, GameObject.Find("Part Position").transform.GetChild(0).transform.position + VectorDiff, progress);
            yield return null;
        }

        if (progress <= 0)
        {
            transform.parent = GameObject.Find("EngineComplete").transform.GetChild(0).transform.GetChild(1).transform;
            gameObject.SetActive(false);
        }

        progress = Mathf.Clamp(progress, 0, 1);
    }

    IEnumerator CountProgress(float time)
    {
        Vector3 targetPosition = ExpandedModel.transform.position;
        while (progress >= 0 && progress <= 1)
        {
            float increment = Time.deltaTime / time;
            progress += increment;
            transform.position = Vector3.Lerp(defaultPosition, targetPosition, progress);
            yield return null;
        }

        progress = Mathf.Clamp(progress, 0, 1);
    }

    private void Update()
    {
        if (progress == 1)
        {
            GameObject.Find("Part Viewer").transform.Rotate(0, speed, 0);
        }

        if (progress <= 0)
        {
            Debug.Log("for");
            
        }
    }
}
