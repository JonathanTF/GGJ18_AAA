using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackwardTapScript : MonoBehaviour
{

    public Button B;
    public hamMovement move;
    public GameObject hamster;

    void Start()
    {
        Button btn = B.GetComponent<Button>();
        if(btn == null)
        btn.onClick.AddListener(TaskOnClick);
        move = hamster.GetComponent<hamMovement>();
    }

    void TaskOnClick()
    {
        print("You have clicked the backward button!");
        move.tapBackward();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
