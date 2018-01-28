using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PainScript : MonoBehaviour {

    const float ZAP_MAX = 1.5f;
    const float ZAP_MIN = 1f;

    public Sprite[] images; 

	AudioSource as_zap;
    float zapness;

    GameObject bloodeyes;

    public Transform camTransform;
    public float shakeDuration = 0f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

        

    public void Zap()
    {
        if (zapness < ZAP_MAX)
        {
            zapness += 0.05f;
            zapness = Mathf.Pow(zapness, 2f);
            Debug.Log("Ouch! zapness: " + zapness);
            shakeAmount = zapness - ZAP_MIN;
            shakeDuration = zapness / 2; 
        }
    }

	// Use this for initialization
	void Start () {
        zapness = ZAP_MIN;
		as_zap = GetComponent<AudioSource> ();
		as_zap.Play();

        bloodeyes = GameObject.FindWithTag("bloodEyes");
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

        bloodeyes.GetComponent<Image>().sprite = images[(int)(20 * Mathf.Clamp01(zapness - ZAP_MIN))];

        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }

    }


}
