using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{

    private GameObject mainSnakeManager;
    // Start is called before the first frame update
    void Start()
    {
        mainSnakeManager = GameObject.FindGameObjectWithTag("manager");
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
            this.transform.parent.GetComponent<SnakeMove>().AddSnakeSegment();
            Debug.Log("Hit Nibble");
        }
        if(collision.gameObject.CompareTag("bounce_enemy"))
        {
            Debug.Log("IM HIT");
            Destroy(mainSnakeManager);
            //Destroy(gameObject);
        }
    }
}
