using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainScript : MonoBehaviour {

    const int ZAP_TOLERANCE = 180;
    const int EMPTY_ZAP = 0;

    int zapness;

    public void Zap()
    {
        zapness += 30;
    }

	// Use this for initialization
	void Start () {
        zapness = EMPTY_ZAP;
	}
	
	// Update is called once per frame
	void Update () {
		if (zapness > EMPTY_ZAP)
        {
            zapness--;
        }
        else if (zapness > ZAP_TOLERANCE)
        {
            Debug.Log("Too much ZAP!!!");
        }
	}
}
