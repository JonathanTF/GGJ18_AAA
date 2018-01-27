using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour {

    private GenerateMapScript levelController;

	// Use this for initialization
	void Start () {
        levelController = GameObject.FindWithTag("LevelController").GetComponent<GenerateMapScript>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        levelController.FinishLevel();
    }
}
