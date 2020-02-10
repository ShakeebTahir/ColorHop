using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundFollow : MonoBehaviour
{
    private GameObject player;
    Vector3 velocity;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "EasyLevel")
        {
            if (player.GetComponent<PlayerScriptEasy>().isDead)
            {
                return;
            }
        }

        else if (SceneManager.GetActiveScene().name == "MediumLevel")
        {
            if (player.GetComponent<PlayerScriptMedium>().isDead)
            {
                return;
            }
        }

        else if (SceneManager.GetActiveScene().name == "HardLevel")
        {
            if (player.GetComponent<PlayerScriptHard>().isDead)
            {
                return;
            }
        }

        else
        {
            if (player.GetComponent<PlayerScriptProgressive>().isDead)
            {
                return;
            }
        }

        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(Camera.main.transform.position.x + 3f, player.transform.position.y, transform.position.z), ref velocity, 1f);
    }
}
