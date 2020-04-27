using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPositionSpeed : MonoBehaviour
{
    public Transform player;
    public Text displayText;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x_position = player.position.x;
        float y_position = player.position.y;
        float z_position = player.position.z;

        float movespeed = rb.velocity.magnitude;

        displayText.text = x_position.ToString("0") + " x " + y_position.ToString("0") + " x " + z_position.ToString("0") + "\n" + movespeed.ToString("0");
    }
}
