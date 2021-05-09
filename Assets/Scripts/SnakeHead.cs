using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{

    private GameObject mainSnakeManager;
    private Rigidbody myRB;
    // Start is called before the first frame update
    void Start()
    {
        mainSnakeManager = GameObject.FindGameObjectWithTag("manager");
        myRB = GetComponent<Rigidbody>();
        //myRB.velocity = transform.forward;//new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("nibble"))
    //    {
    //        this.transform.parent.GetComponent<SnakeMove>().AddSnakeSegment();
    //        Debug.Log("IM HIT");
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("nibble"))
        {
            //this.transform.parent.GetComponent<SnakeMove>().AddSnakeSegment();
            this.transform.parent.GetComponent<SnakeMoveWithDestroyingBody>().AddSnakeSegment();
            Debug.Log("Hit Nibble");
        }
        if(collision.gameObject.CompareTag("bounce_enemy"))
        {
            Debug.Log("HEAD HIT ENEMY. GAME OVER");
            Destroy(mainSnakeManager);
            //Destroy(gameObject);
        }
        if(collision.collider.tag == "wall")
        {
            float curSpeed = mainSnakeManager.GetComponent<SnakeMove>().speed;
            Debug.Log("Object Up: " + transform.up + " || object Quarternion:  " + transform.rotation + "|| normal of collison: " + collision.GetContact(0).normal);
            var direction = Vector3.Reflect(transform.forward, collision.GetContact(0).normal);
            var rot = Quaternion.FromToRotation(transform.forward, direction);
            Debug.Log("Reflection Quarternion: " + rot);
            transform.rotation *= new Quaternion(0, (rot.y == 0 ? 1 : rot.y), 0, rot.w);
            //transform.rotation *= rot;
        }
    }

    //private void Bounce(Vector3 collisionNormal)
    //{
    //    var speed = lastFrameVelocity.magnitude;
    //    var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

    //    //Debug.Log("Out Direction: " + direction  +" || Speed: " + speed);
    //    rb.velocity = direction * Mathf.Max(speed, minVelocity);
    //}
}
