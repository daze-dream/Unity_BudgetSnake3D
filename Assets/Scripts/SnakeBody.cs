using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>The small segments of the snake</summary>
public class SnakeBody : MonoBehaviour
{
    public bool isHit;
    public ParticleSystem SegmentDestroyFX;
    // Start is called before the first frame update
    void Start()
    {
        isHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// if hit, set its hit variable to true for the snake movement manager to find and delete.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("bounce_enemy"))
        {
            var temp = Instantiate(SegmentDestroyFX, this.transform.position, Quaternion.identity);
            isHit = true;
        }
    }

    /// <summary>
    /// DEPRECATED: play a sound when it is hit. 
    /// </summary>
    public void playFX()
    {
        var temp = Instantiate(SegmentDestroyFX, this.transform.position, Quaternion.identity);
    }
}
