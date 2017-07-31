using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBlinker : MonoBehaviour {
    bool isColonShown = true;
    float timeSinceLastSwap = 0;
    Sprite withColon;
    Sprite withoutColon;

    Sprite sprite
    {
        get { return GetComponent<SpriteRenderer>().sprite; }
        set { GetComponent<SpriteRenderer>().sprite = value; }
    }

	// Use this for initialization
	void Start () {
		withColon = Resources.Load<Sprite>("Time");
        withoutColon = Resources.Load<Sprite>("TimeNoColon");
    }
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSwap += Time.deltaTime;

        if(timeSinceLastSwap >=1f)
        {
            if(isColonShown)
            {
                sprite = withoutColon;
                isColonShown = false;
                timeSinceLastSwap = 0.0f;
                    
            }
            else
            {
                sprite = withColon;
                isColonShown = true;
                timeSinceLastSwap = 0.0f;
            }
        }
	}
}
