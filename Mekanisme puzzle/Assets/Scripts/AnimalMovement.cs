using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public GameObject player;
    public float animalSpeed = 5f;

    //public float activationDistance = 1f;

    private bool isControllingAnimal = false;
    private CameraFollow cameraFollow;
    private GameObject controlledAnimal;
    private Vector2 animalInput;

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float distance = Vector2.Distance(transform.position, other.transform.position);
            if (distance <= activationDistance)
            {
                Update();
            }
        }
    }*/

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isControllingAnimal)
        {
            GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
            float minDistance = 3f;
            GameObject nearestAnimal = null;
            foreach (GameObject animal in animals)
            {
                float distance = Vector2.Distance(player.transform.position, animal.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestAnimal = animal;
                }
            }
            if (nearestAnimal != null)
            {
                isControllingAnimal = true;
                controlledAnimal = nearestAnimal;
                player.GetComponent<PlayerController>().enabled = false;
                Camera.main.GetComponent<CameraFollow>().SetTarget(controlledAnimal);
                //cameraFollow.SetTarget(collider.gameObject);
            }
        }

        if (isControllingAnimal)
        {
            animalInput.x = Input.GetAxisRaw("Horizontal");
            controlledAnimal.GetComponent<Rigidbody2D>().velocity = animalInput.normalized * animalSpeed;

            if (Input.GetKeyDown(KeyCode.Q))
            {
                isControllingAnimal = false;
                controlledAnimal.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                player.GetComponent<PlayerController>().enabled = true;
                Camera.main.GetComponent<CameraFollow>().SetTarget(player);
                //cameraFollow.SetTarget(gameObject);
            }
        }
    }
}