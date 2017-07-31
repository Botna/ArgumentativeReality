using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandBasedOnFailedInspection : MonoBehaviour {

    Sprite ExpandedSprite;
    
    // Use this for initialization
    void Start () {
        ExpandedSprite = Resources.Load<Sprite>("ApptInfo/sylvia/servicesWithNewService");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addFailedOpcodeFromTire()
    {
        this.transform.localScale += new Vector3(0.0f, 0.0f, .3f);
        GetComponent<SpriteRenderer>().sprite = ExpandedSprite;
    }
}
