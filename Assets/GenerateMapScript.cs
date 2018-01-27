using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMapScript : MonoBehaviour {

    public GameObject Wall;
    public GameObject StartTile;
    public GameObject Finish;
    public GameObject Harry;
    public GameObject Ground;

    const char WALL_CHAR = '#';
    const char START_CHAR = 'S';
    const char FIN_CHAR = 'F';

    const float WALL_SIZE = 1.5f;
    const int LENGTH = 11;
    const int WIDTH = 11;
    string[] lines;

    int level;

	// Use this for initialization
	void Start () {
        level = 1;
        LoadMaze("Mazes/maze" + level);
	}

    public void FinishLevel()
    {
        // increment level, destroy level, load next level
        level++;
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        LoadMaze("Mazes/maze" + level);
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

        // Generate Ground
        GameObject ground = Instantiate<GameObject>(Ground, new Vector3(5f, -0.5f, 5f) * WALL_SIZE, Quaternion.identity);
        ground.transform.localScale = Vector3.one * WALL_SIZE * LENGTH * 100;

        // Generate walls and stuff
        for (int i = 0; i < LENGTH; i++)
        {
            for (int j = 0; j < WIDTH; j++)
            {
                char tileChar = lines[i][j];

                

                switch (tileChar){
                    case (WALL_CHAR):
                        GameObject wall = Instantiate<GameObject>(Wall, new Vector3(i, 0, j) * WALL_SIZE, Quaternion.identity);
                        wall.transform.localScale = Vector3.one * WALL_SIZE;
                        wall.transform.parent = gameObject.transform;
                        break;
                    case (START_CHAR):
                        GameObject start = Instantiate<GameObject>(StartTile, new Vector3(i, -0.5f, j) * WALL_SIZE, Quaternion.AngleAxis(90, Vector3.right));
                        GameObject harry = Instantiate<GameObject>(Harry, new Vector3(i, 0, j) * WALL_SIZE, Quaternion.identity); 
                        start.transform.parent = gameObject.transform;
                        harry.transform.parent = gameObject.transform;
                        break;
                    case (FIN_CHAR):
                        GameObject finish = Instantiate<GameObject>(Finish, new Vector3(i, 0, j) * WALL_SIZE, Quaternion.identity);
                        finish.transform.parent = gameObject.transform;
                        break;

                    default: break;
                }

            }
        }
    }
}
