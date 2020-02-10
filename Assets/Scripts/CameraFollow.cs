using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    Vector3 vel;
    public GameObject player;

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

        Vector3 target = new Vector3(player.transform.position.x+1.5f, player.transform.position.y, player.transform.position.z-1f);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref vel, 0.5f);
        
    }
}
