using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 initialVelocity;
    private float minVelocity = 6f;

    private Vector3 lastFrameVelocity;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.velocity = new Vector3(2, 0, 6);
    }

    // Update is called once per frame
    void Update()
    {
        lastFrameVelocity = rb.velocity;
        //Debug.Log("Last Frame Velocity: " + lastFrameVelocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("head"))
        //{
        //    Destroy(collision.gameObject);
        //}
        //else
        //{
        //    Bounce(collision.GetContact(0).normal);
        //}
        if (collision.collider.tag != "nibble")
        {
            Bounce(collision.GetContact(0).normal);
        }

        //Destroy(gameObject);
        //Debug.Log("hit");
        //Debug.Log(rb.velocity);
    }

    private void Bounce(Vector3 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        //Debug.Log("Out Direction: " + direction  +" || Speed: " + speed);
        rb.velocity = direction * Mathf.Max(speed, minVelocity);
    }

    private void SetVelocity(Vector3 vel)
    {
        rb.velocity = vel;
    }
}
