using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Player Movement");

        moveSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal_movement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float vertical_movement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(horizontal_movement, 0f, vertical_movement);

        if (transform.position.y < 0f)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
