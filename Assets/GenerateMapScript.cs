using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMapScript : MonoBehaviour {

    public GameObject Wall;
    public GameObject StartTile;
    public GameObject Finish;
    public GameObject Harry;

    const char WALL_CHAR = 'W';
    const char START_CHAR = 'S';
    const char FIN_CHAR = 'F';

    const int LENGTH = 11;
    const int WIDTH = 11;
    string[] lines;

	// Use this for initialization
	void Start () {
        LoadMaze("Mazes/test");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadMaze(string filePath) {
        if (filePath == "") return;

        try
        {
            TextAsset binData = Resources.Load(filePath) as TextAsset;
            lines = binData.text.Split('\n');
            
        }
        catch(Exception e)
        {
            Debug.Log("could not load level");
        }

        for (int i = 0; i < LENGTH; i++)
        {
            for (int j = 0; j < WIDTH; j++)
            {
                char tileChar = lines[i][j];

                switch (tileChar){
                    case (WALL_CHAR):   Instantiate<GameObject>(Wall, new Vector3(i, 0, j), Quaternion.identity); break;
                    case (START_CHAR):
                        Instantiate<GameObject>(StartTile, new Vector3(i, 0, j), Quaternion.AngleAxis(90, Vector3.right));
                        Instantiate<GameObject>(Harry, new Vector3(i, 0, j), Quaternion.identity); break;
                    case (FIN_CHAR): Instantiate<GameObject>(Finish, new Vector3(i, 0, j), Quaternion.identity); break;
                    default: break;
                }

            }
        }
    }
}
