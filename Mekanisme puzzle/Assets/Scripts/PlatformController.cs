using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public GameObject[] platforms;
    public PlayerController pcScript;
    public float activationDistance;

    GameObject player;

    private int currentPlatformIndex = 0;
    private bool isControllingPlatforms = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= activationDistance)
        {
            ActivateUpdateFunction();
        }
    }
    
    void ActivateUpdateFunction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isControllingPlatforms)
            {
                DisableScript();
                isControllingPlatforms = true;
                platforms[currentPlatformIndex].GetComponent<PlatformMovement>().StartControlling();
            }
            /*else
            {
                EnableScript();
                isControllingPlatforms = false;
                platforms[currentPlatformIndex].GetComponent<PlatformMovement>().StopControlling();
            }*/
        }

        if (isControllingPlatforms && Input.GetKeyDown(KeyCode.R))
        {
            platforms[currentPlatformIndex].GetComponent<PlatformMovement>().StopControlling();
            currentPlatformIndex = (currentPlatformIndex + 1) % platforms.Length;
            platforms[currentPlatformIndex].GetComponent<PlatformMovement>().StartControlling();
        }

        if (isControllingPlatforms && Input.GetKeyDown(KeyCode.Q))
        {
            EnableScript();
            isControllingPlatforms = false;
            platforms[currentPlatformIndex].GetComponent<PlatformMovement>().StopControlling();
        }
    }

    public void EnableScript()
    {
        pcScript.enabled = true;
    }

    public void DisableScript()
    {
        pcScript.enabled = false;
    }
}