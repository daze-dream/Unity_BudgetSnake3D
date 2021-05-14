using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour : MonoBehaviour
{
    public ParticleSystem nibbleGetPartciles;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("head"))
    //    {
    //        Destroy(gameObject);

    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("head"))
        {
            nibbleGetPartciles.Play();
            Destroy(gameObject);
        }
    }
}
