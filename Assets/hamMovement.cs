using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hamMovement : MonoBehaviour {

    public bool move = true;
    public float velocity = 2;
    public float turnVelocity = 8;
    public float fb_control = 0;
    public float secTillHamSlow = 0.0f;
    public float secTillHamCtrl = 10;
    private float hamTime = 0;
    private CharacterController control;
    private IEnumerator coroutine;

    // Use this for initialization
    void Start()
    {

        control = GetComponent<CharacterController>();

        coroutine = DoCheck();
        StartCoroutine(coroutine);
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
        print("tapped forward");
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
    private Quaternion qTo = Quaternion.Euler(Vector3.down * 90f);


    public void tapRight()
    {

        hamTime = 0;
        rotation += 30.0f;
        qTo = Quaternion.Euler(0.0f, rotation, 0.0f);

    }

    public void tapLeft()
    {

        hamTime = 0;
        rotation -= 30.0f;
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

            transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, speed * 2 * Time.deltaTime);

        }
    }

    private void hamTimer()
    {
        hamTime++;
        if((hamTime/10 >= secTillHamSlow))
        {
 
            if (fb_control < 0)
            {
                fb_control += .1f;
                if (fb_control > 0)
                {
                    fb_control = 0f;
                }
            }else if(fb_control > 0)
            {
                fb_control -= .1f;
                if (fb_control < 0)
                {
                    fb_control = 0;
                }
            }
        }
    }



}
