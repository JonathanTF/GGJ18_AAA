using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxMovement : MonoBehaviour {

    public bool move = true;
    public float velocity = 10;
    public float turnVelocity = 10;
    Rigidbody rb;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (move)
        {
             
            rb.velocity = transform.forward * Input.GetAxis("Vertical") * velocity;

            transform.Rotate(Vector3.up, Input.GetAxis("Horizontal"));

        }
    }
}
