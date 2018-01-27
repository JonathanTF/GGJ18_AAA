﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hamMovement : MonoBehaviour {

    public bool move = true;
    public float velocity = 10;
    public float turnVelocity = 10;
    public float fb_control = 0;
    public float secTillHamSlow = 4;
    public float secTillHamCtrl = 10;
    private float hamTime = 0;
    private CharacterController control;

    // Use this for initialization
    void Start()
    {

        control = GetComponent<CharacterController>();
    }


    IEnumerator DoCheck()
    {
        for (; ; )
        {
            hamTimer();
            yield return new WaitForSeconds(.1f);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void clamp_fb()
    {
        if(fb_control < -1)
        {
            fb_control = -1;
        }else if(fb_control > 1)
        {
            fb_control = 1;
        }
    }

    public void tapForward()
    {
        fb_control += 0.1f;
        clamp_fb();
        hamTime = 0;
    }

    public void tapBackward()
    {
        fb_control -= 0.1f;
        clamp_fb();
        hamTime = 0;
    }


    public float speed = 10.0f;
    private float rotation = 0.0f;
    private Quaternion qTo = Quaternion.identity;


    public void tapRight()
    {

        hamTime = 0;
        rotation += 15.0f;
        qTo = Quaternion.Euler(0.0f, rotation, 0.0f);

    }

    public void tapLeft()
    {

        hamTime = 0;
        rotation -= 15.0f;
        qTo = Quaternion.Euler(0.0f, rotation, 0.0f);


    }

    Vector3 moveDirection;

    private void FixedUpdate()
    {
        if (move)
        {

            moveDirection = new Vector3(0, 0, fb_control);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            control.Move(moveDirection * Time.deltaTime);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, speed * Time.deltaTime);

        }
    }

    private void hamTimer()
    {
        hamTime++;
        if((hamTime/10) >= secTillHamCtrl)
        {
            //hamster does random action?   
        }else if((hamTime/10 >= secTillHamSlow))
        {
            velocity = 0;
        }
    }



}