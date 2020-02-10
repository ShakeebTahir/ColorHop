using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileScript : MonoBehaviour
{
    float yPos;
    Generator generator;
    GeneratorMedium generatorMedium;
    GeneratorHard generatorHard;
    GeneratorProgressive generatorProgressive;

    void Start()
    {
        yPos = transform.position.y;

        if (SceneManager.GetActiveScene().name == "EasyLevel")
        {
            generator = GameObject.Find("TilesGenerator").GetComponent<Generator>();
        }

        else if (SceneManager.GetActiveScene().name == "MediumLevel")
        {
            generatorMedium = GameObject.Find("TilesGenerator").GetComponent<GeneratorMedium>();
        }

        else if (SceneManager.GetActiveScene().name == "HardLevel")
        {
            generatorHard = GameObject.Find("TilesGenerator").GetComponent<GeneratorHard>();
        }

        else
        {
            generatorProgressive = GameObject.Find("TilesGenerator").GetComponent<GeneratorProgressive>();
        }

    }

    void Update()
    {
        if(transform.position.y < yPos - 10f)
        {
            if (SceneManager.GetActiveScene().name == "EasyLevel")
            {
                generator.GenerateTiles();
            }

            else if(SceneManager.GetActiveScene().name == "MediumLevel")
            {
                generatorMedium.GenerateTiles();
            }

            else if (SceneManager.GetActiveScene().name == "HardLevel")
            {
                generatorHard.GenerateTiles();
            }

            else
            {
                generatorProgressive.GenerateTiles();
            }

            Destroy(this.gameObject);
        }
    }
}
