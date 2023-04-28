using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float force = 10f;
    //public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isControlled = false;
    private CameraFollow cameraFollow;
    private Vector3 startPosition;
    
    void Start()
    {
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    void Update()
    {
        if (!isControlled)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            Vector2 movement = new Vector2(horizontalInput, verticalInput * force);
            movement.Normalize();

            transform.Translate(movement * speed * Time.deltaTime);

            /*if (Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }*/
        }
    }
}