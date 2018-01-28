using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class imageSizeTest : MonoBehaviour {

    public Image image;
    public float speed = 2;
    // Use this for initialization
    void Start () {
        StartCoroutine(Grow());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Grow()
    {
        for (float i = 0; i <= 1; i += Time.deltaTime * speed)
        {
            //image.color = new Color(1, 1, 1, 1);

            

            yield return null;
        }
    }
}
