using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDotsUnderHood : MonoBehaviour {
	public void showDots()
    {
		//translateDotsToCurrentPosition ();
        for (int i = 0; i < 3; i++)
        {
            this.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
        }
    }

	public void hideDots()
    {
        for(int i = 0; i <3; i++)
        {
            this.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
        }
    }

	
}
