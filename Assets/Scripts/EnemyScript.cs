using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary> <para> physicsless bounce adapted from: https://unity3d.college/2017/07/03/using-vector3-reflect-to-cheat-ball-bouncing-physics-in-unity/ </para>
/// enemy behaviour
/// </summary>
public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 initialVelocity;
    private float minVelocity = 6f;

    private Vector3 lastFrameVelocity;
    private Rigidbody rb;
    private AudioSource thisSource;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thisSource = GetComponent<AudioSource>();
        //DEBUG
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
        if (collision.collider.tag != "nibble")
        {
            Bounce(collision.GetContact(0).normal);
        }
    }

    /// <summary>
    /// physicsless bounce using Vector Reflection and normal angles
    /// </summary>
    /// <param name="collisionNormal"></param>
    private void Bounce(Vector3 collisionNormal)
    {
        thisSource.Play();
        ///keep the speed it collided at
        var speed = lastFrameVelocity.magnitude;
        ///get the normal of collision and reflect off of that
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);
        ///and set it as the new velocity.
        //Debug.Log("Out Direction: " + direction  +" || Speed: " + speed);
        rb.velocity = direction * Mathf.Max(speed, minVelocity);
    }

    /// <summary>
    /// NOT USED: sets a velocity, intended for debugging or external use
    /// </summary>
    /// <param name="vel"></param>
    private void SetVelocity(Vector3 vel)
    {
        rb.velocity = vel;
    }
}
