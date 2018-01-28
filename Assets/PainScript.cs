using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainScript : MonoBehaviour {

    const float ZAP_MAX = 1.3f;
    const float ZAP_MIN = 1f;
	AudioSource as_zap;
    float zapness;
	float zap_delay = 0.25f;

    public void Zap()
    {
        if (zapness < ZAP_MAX)
        {
            //zapness += 0.15f;
            zapness *= 1.04f;
			zap_delay = 0.25f;
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

		zap_delay -= 0.01f;
		if (zapness > ZAP_MIN && zap_delay <= 0.0f)
        {
            zapness -= 0.03f;
			Debug.Log("Ouch! zapness: " + zapness);
        }
		if (zapness > ZAP_MAX) {
			Debug.Log ("Too much ZAP!!!");
		}
		as_zap.pitch = zapness;
	}
}