using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour {

    private const float multiplier = 0.026f;
    private int count = 0;
    private const int maxCount = 180;
    private float direction = 1f;

    private bool liftGate = false;
    private bool dropGate = false;

    private bool triggered = false;

    public void SetDirection(float dir)
    {
        direction = dir;
    }

    public void GateOpen()
    {
        if (!triggered)
        {
            liftGate = true;
            dropGate = false;
        }
    }
        

	// Use this for initialization
	void Start () {
        
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            GateOpen();
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (liftGate == true)
        {
            if (count >= maxCount)
            {
                liftGate = false;
                count = 0;
                triggered = true;
            }
            else
            {
                transform.position = transform.position + direction * Vector3.up * multiplier * Mathf.Sin(Mathf.Deg2Rad * count);
                count++;
            }
        }

	}
}
