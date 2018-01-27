using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForwardTapScript : MonoBehaviour {

    public Button yourButton;
    public hamMovement move;
    public GameObject hamster;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        move = hamster.GetComponent<hamMovement>();
    }

    void TaskOnClick()
    {
        print("You have clicked the forward button!");
        move.tapForward();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
