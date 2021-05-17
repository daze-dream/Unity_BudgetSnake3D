using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Nibble mechanics and behaviour.
/// </summary>
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
    
    /// <summary>
    /// summons the partcile effects on collision
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("head"))
        {
            var temp = Instantiate(nibbleGetPartciles, this.transform.position, Quaternion.identity);
            Debug.Log(temp.transform.position);
            //temp.Play();
            Destroy(gameObject);
        }
    }
}
