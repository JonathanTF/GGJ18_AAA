using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class opaqTouch : MonoBehaviour {

    public Image image;

    public float speed = 2;

	// Use this for initialization
	void Start () {
        image.color = new Color(1, 1, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void tap()
    {
        StartCoroutine(FadeImage());
    }

    IEnumerator FadeImage()
    {

        for (float i = 0; i <= 1; i += Time.deltaTime*speed)
        {
            image.color = new Color(1, 1, 1, i);
            yield return null;
        }

        for (float i = 1; i >= 0; i -= Time.deltaTime*speed)
        {
            image.color = new Color(1, 1, 1, i);
            yield return null;
        }

    }

    IEnumerator rapidClicker()
    {
        for (float i = 0; i <= 1; i += Time.deltaTime * speed)
        {
            image.color = new Color(1, 1, 1, 1);
            yield return null;
        }
    }
}
