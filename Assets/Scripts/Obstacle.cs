using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float speed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector3.right * speed * Time.fixedDeltaTime);
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }
}
