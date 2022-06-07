using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    
    private const float MAX_SPEED = 4f, 
        ACCELERATION = 0.2f;

    private bool mustMove;
    private float speed;

    private Vector3 startPosition;

    public ParticleSystem smoke;
    public Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && GameManager.instance.GetState() == GameManager.State.PLAYING)
        {
            mustMove = true;
            
        }
        else
        {
            mustMove = false;
        }
    }

    private void FixedUpdate()
    {
        if (mustMove)
        {
            speed = Math.Min(speed + ACCELERATION, MAX_SPEED);
            var emission = smoke.emission;
            emission.rateOverTime = 200;
        }
        else
        {
            speed = Math.Max(speed - ACCELERATION, 0f);
            var emission = smoke.emission;
            emission.rateOverTime = 0;
        }
        
        rb.MovePosition(rb.position + new Vector3(0, 0, speed));
    }

    private void Collide(Vector3 carPosition, float force)
    {
        Vector3 vector = (transform.position - carPosition) * force;
        
        rb.AddForce(vector);
        rb.AddTorque(new Vector3(60, 0, 0));
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Obstacle"))
        {
            UIManager.instance.ShowLoseMenu();
            GameManager.instance.SetStateToFinished();
            Collide(other.transform.position, 500);
            
            AudioManager.instance.Play("crash");
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Finish"))
        {
            animator.enabled = true;
            UIManager.instance.ShowWinMenu();
            AudioManager.instance.Play("win");
            GameManager.instance.SetStateToFinished();
        }
    }

    public void RestartPlayer()
    {
        rb.isKinematic = true;
        transform.position = startPosition;
        transform.localEulerAngles = Vector3.zero;
        rb.isKinematic = false;
        
        animator.enabled = false;
    }
}
