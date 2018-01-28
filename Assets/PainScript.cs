using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainScript : MonoBehaviour {

    const float ZAP_MAX = 2f;
    const float ZAP_MIN = 1f;
	AudioSource as_zap;
    float zapness;

    public void Zap()
    {
        if (zapness < ZAP_MAX)
        {
            zapness += 0.05f;
            zapness = Mathf.Pow(zapness, 2f);
            Debug.Log("Ouch! zapness: " + zapness);
        }
    }

	// Use this for initialization
	void Start () {
        zapness = ZAP_MIN;
		as_zap = GetComponent<AudioSource> ();
		as_zap.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (zapness > ZAP_MIN)
        {
            zapness -= 0.01f;
        }
        if (zapness > ZAP_MAX)
        {
            Debug.Log("Too much ZAP!!!");
        }
		as_zap.pitch = zapness;
	}
}
