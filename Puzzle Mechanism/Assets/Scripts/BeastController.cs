using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastController : MonoBehaviour
{
    public GameObject player;
    public GameObject[] beasts;
    public float speed = 5f;
    public float switchDelay = 0.2f;
    public PlayerController pcScript;
    public float activationDistance;

    private int currentBeastIndex = 0;
    private bool controllingBeast = false;
    private GameObject currentBeast;
    private Vector3 cameraPosition;
    private CameraFollow cameraFollow;

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
        if (Input.GetKeyDown(KeyCode.E) && !controllingBeast)
        {
            DisableScript();
            currentBeast = beasts[currentBeastIndex];
            currentBeast.SetActive(true);
            controllingBeast = true;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            currentBeast.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Camera.main.GetComponent<CameraFollow>().SetTarget(currentBeast);
        }
        else if (Input.GetKeyDown(KeyCode.R) && controllingBeast)
        {
            DisableScript();
            currentBeast.SetActive(true);
            currentBeastIndex = (currentBeastIndex + 1) % beasts.Length;
            currentBeast = beasts[currentBeastIndex];
            currentBeast.SetActive(true);
            currentBeast.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Camera.main.GetComponent<CameraFollow>().SetTarget(currentBeast);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && controllingBeast)
        {
            currentBeast.SetActive(false);
            controllingBeast = false;
            Camera.main.GetComponent<CameraFollow>().SetTarget(player);
            EnableScript();
        }

        if (controllingBeast)
        {
            DisableScript();
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            currentBeast.GetComponent<Rigidbody2D>().velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
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
