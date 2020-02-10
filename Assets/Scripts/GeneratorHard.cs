using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorHard : MonoBehaviour
{

    public GameObject tilePrefabOne;
    public GameObject tilePrefabTwo;
    public GameObject tilePrefabThree;
    public GameObject tilePrefabFour;

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
        int random = Random.Range(1, 5);
        if (random == 1)
        {
            GenerateColourOne();
        }
        else if (random == 2)
        {
            GenerateColourTwo();
        }
        else if (random == 3)
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


