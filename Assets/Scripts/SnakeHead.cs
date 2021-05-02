using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("nibble"))
        {
            this.transform.parent.GetComponent<SnakeMove>().AddSnakeSegment();
            Debug.Log("IM HIT");
        }
    }
}
