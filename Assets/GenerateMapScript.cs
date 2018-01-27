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

    public GameObject ABJMOQ;
    public GameObject ACDEMP;
    public GameObject ADENVZ;
    public GameObject BIFORX;
    public GameObject EGINTV;
    public GameObject EGKLUV;
    public GameObject EHINPS;
    public GameObject GILRUW;

    const int ABJ = 0;
    const int ACD = 1;
    const int ADE = 2;
    const int BIF = 3;
    const int EGI = 4;
    const int EGK = 5;
    const int EHI = 6;
    const int GIL = 7;

    const char WALL_CHAR = '#';
    const char START_CHAR = 'S';
    const char FIN_CHAR = 'F';

    const float WALL_SIZE = 2f;
    const int LENGTH = 11;
    const int WIDTH = 11;
    string[] lines;

    int level;

    private GameObject generateCube(int cubeType, Vector3 pos, Vector3 direction)
    {
        GameObject cube;
        switch (cubeType)
        {
            case ABJ: cube = Instantiate<GameObject>(ABJMOQ, pos, Quaternion.identity);  break;
            case ACD: cube = Instantiate<GameObject>(ACDEMP, pos, Quaternion.identity); break;
            case ADE: cube = Instantiate<GameObject>(ADENVZ, pos, Quaternion.identity); break;
            case BIF: cube = Instantiate<GameObject>(BIFORX, pos, Quaternion.identity); break;
            case EGI: cube = Instantiate<GameObject>(EGINTV, pos, Quaternion.identity); break;
            case EGK: cube = Instantiate<GameObject>(EGKLUV, pos, Quaternion.identity); break;
            case EHI: cube = Instantiate<GameObject>(EHINPS, pos, Quaternion.identity); break;
            case GIL: cube = Instantiate<GameObject>(GILRUW, pos, Quaternion.identity); break;
            default : cube = Instantiate<GameObject>(Wall, pos, Quaternion.identity); break;
        }

        return cube;
    }

    // Use this for initialization
    void Start()
    {
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
                        //GameObject wall = Instantiate<GameObject>(Wall, new Vector3(i, 0, j) * WALL_SIZE, Quaternion.identity);

                        GameObject wall = generateCube((int)UnityEngine.Random.Range(0, 8), new Vector3(i, 0, j) * WALL_SIZE, Vector3.zero);
                        wall.transform.localScale = Vector3.one * WALL_SIZE * 10;
                        wall.transform.Rotate(new Vector3((int)UnityEngine.Random.Range(0, 4) * 90, (int)UnityEngine.Random.Range(0, 4) * 90, (int)UnityEngine.Random.Range(0, 4) * 90));
                        wall.transform.parent = gameObject.transform;
                        break;
                    case (START_CHAR):
                        GameObject start = Instantiate<GameObject>(StartTile, new Vector3(i, -0.5f, j) * WALL_SIZE, Quaternion.AngleAxis(90, Vector3.right));
                        GameObject harry = Instantiate<GameObject>(Harry, new Vector3(i, 0, j) * WALL_SIZE, Quaternion.identity);
                        harry.transform.Rotate(Vector3.down * 90);
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
