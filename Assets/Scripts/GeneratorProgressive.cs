using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorProgressive : MonoBehaviour
{

    public GameObject tilePrefabOne;
    public GameObject tilePrefabTwo;
    public GameObject tilePrefabThree;
    public GameObject tilePrefabFour;

    private float xDiff = 1.1f;
    private float yDiff = 1.2f;

    private float xPos = 0f;
    private float yPos = 0f;

    private int tilesGenerated;
    private int randomNum;

    void Start()
    {
        for(int i = 0; i < 6; ++i)
        {
            GenerateTiles();
        }

        tilesGenerated = 6;

    }

    public void GenerateTiles()
    {
        tilesGenerated += 1;

        if (tilesGenerated <= 25)
        {
            randomNum = Random.Range(1, 3);
        }
        else if (tilesGenerated > 25 & tilesGenerated <= 50)
        {
            randomNum = Random.Range(1, 4);
        }
        else if (tilesGenerated > 50)
        {
            randomNum = Random.Range(1, 5);
        }

        if (randomNum == 1)
        {
            GenerateColourOne();
        }
        else if (randomNum == 2)
        {
            GenerateColourTwo();
        }
        else if (randomNum == 3)
        {
            GenerateColourThree();
        }
        else
        {
            GenerateColourFour();
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

    void GenerateColourThree()
    {
        xPos += xDiff;
        yPos += yDiff;

        Instantiate(tilePrefabThree, new Vector3(xPos, yPos, 0), tilePrefabThree.transform.rotation);
    }

    void GenerateColourFour()
    {
        xPos += xDiff;
        yPos += yDiff;

        Instantiate(tilePrefabFour, new Vector3(xPos, yPos, 0), tilePrefabFour.transform.rotation);
    }

}


