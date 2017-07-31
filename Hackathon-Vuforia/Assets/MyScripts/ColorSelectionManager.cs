using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelectionManager : MonoBehaviour {

    Sprite green;
    Sprite red;
    Sprite neutral;

    
	// Use this for initialization
	void Start () {
        red = Resources.Load<Sprite>("tireConditionBad");
        green = Resources.Load<Sprite>("tireConditionGood");
        neutral = Resources.Load<Sprite>("tireConditionList");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void makeGreen()
    {
        this.GetComponent<SpriteRenderer>().sprite = green;
    }

    public void makeRed()
    {
        this.GetComponent<SpriteRenderer>().sprite = red;
    }
    public void makeNeutral()
    {
        this.GetComponent<SpriteRenderer>().sprite = neutral;
    }
}
