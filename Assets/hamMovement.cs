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
    private PainScript brainOfPain;
    private IEnumerator coroutine;
    public GameObject harry;
    private Animator animCtrl;
    public bool isMoving = false;

    GameObject BGM;
    private float rotation;

    // Use this for initialization
    void Start()
    {

        control = GetComponent<CharacterController>();
        control.enabled = true;

        coroutine = DoCheck();
        StartCoroutine(coroutine);
        BGM = GameObject.FindWithTag("GameController");
        brainOfPain = BGM.GetComponent<PainScript>();

        rotation = transform.rotation.eulerAngles.y;

        animCtrl = harry.GetComponent<Animator>();
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
    void Update() {
        if (fb_control == 0)
        {
            animCtrl.SetBool("isMoving", false);
            animCtrl.speed = 1;
        }
        else if(fb_control > 0)
        {
            animCtrl.SetBool("isMoving", true);
            animCtrl.speed = 3 * fb_control;
        }
        else
        {
            animCtrl.SetBool("isMoving", true);
            animCtrl.speed = -3 * fb_control;
        }

        print(fb_control);
        
    }

    private void clamp_fb()
    {
        if (fb_control < -1)
        {
            fb_control = -1;
        } else if (fb_control > 1)
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

        brainOfPain.Zap();
    }

    public void tapBackward()
    {
        fb_control -= 0.1f;
        clamp_fb();
        hamTime = 0;
        brainOfPain.Zap();

    }


    public float speed = 10.0f;

    private Quaternion qTo = Quaternion.Euler(Vector3.down * 90f);

    bool rightTapCD = false;
    public void tapRight()
    {

        hamTime = 0;

        if (rightTapCD)
        {
            rotation += 0.0f;
        }
        else
        {
            rotation += 30.0f;
            rightTapCD = true;
            StartCoroutine(RightRotateTimer());
        }

        qTo = Quaternion.Euler(0.0f, rotation, 0.0f);
        brainOfPain.Zap();

    }

    IEnumerator RightRotateTimer()
    {
        yield return new WaitForSeconds(.35f);
        rightTapCD = false;
    }

    bool leftTapCD = false;
    public void tapLeft()
    {

        hamTime = 0;

        if (leftTapCD)
        {
            rotation -= 0.0f;
        }
        else
        {
            rotation -= 30.0f;
            leftTapCD = true;
            StartCoroutine(LeftRotateTimer());
        }

        

        qTo = Quaternion.Euler(0.0f, rotation, 0.0f);

        brainOfPain.Zap();

    }

    IEnumerator LeftRotateTimer()
    {
        yield return new WaitForSeconds(.35f);
        leftTapCD = false;
    }

    Vector3 moveDirection;

    private void FixedUpdate()
    {
        if (move)
        {
            
            moveDirection = new Vector3(0, 0, fb_control);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            print(control.velocity.magnitude);

            

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

            if (control.velocity.magnitude.Equals(0))
            {
                fb_control = 0;
            }
        }
    }



}
