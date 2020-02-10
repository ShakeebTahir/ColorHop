using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    public GameObject tilePrefabOne;
    public GameObject tilePrefabTwo;

    private float xDiff = 1.1f;
    private float yDiff = 1.2f;

    private float xPos = 0f;
    private float yPos = 0f;

    void Start()
    {
        for(int i = 0; i < 6; ++i)
        {
            GenerateTiles();
        }
    }

    public void GenerateTiles()
    {
        int random = Random.Range(1, 3);
        if (random == 1)
        {
            GenerateColourOne();
        }
        else
        {
            GenerateColourTwo();
        }
    }

    void GenerateColourOne()
    {
        xPos += xDiff;
        yPos += yDiff;

        Instantiate(tilePrefabOne, new Vector3(xPos, yPos, 0), tilePrefabOne.transform.rotation);
    }

    void GenerateColourTwo()
    {
        xPos += xDiff;
        yPos += yDiff;

        Instantiate(tilePrefabTwo, new Vector3(xPos, yPos, 0), tilePrefabTwo.transform.rotation);
    }

}


