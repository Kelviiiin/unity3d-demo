﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 5f;

    private Rigidbody rb;

    private bool cubeIsGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal_movement = Input.GetAxis("Horizontal");
        float vertical_movement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal_movement, 0, vertical_movement);

        rb.AddForce(movement * moveSpeed);

        if (transform.position.y < 0f || transform.position.x < 0 || transform.position.x > 50 || transform.position.z < -50 || transform.position.z > 0)
        {
            FindObjectOfType<GameManager>().GameOver();
        }

        if (Input.GetButtonDown("Jump") && cubeIsGrounded) 
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            cubeIsGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obstacle"))
        {
            cubeIsGrounded = true;
        }
    }
}
