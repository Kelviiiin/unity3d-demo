using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    public Vector3 offset = new Vector3(0, 2, -4);

    void FixedUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
