using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("bounce_enemy"))
        {
            var temp = Instantiate(SegmentDestroyFX, this.transform.position, Quaternion.identity);
            isHit = true;
        }
    }

    public void playFX()
    {
        var temp = Instantiate(SegmentDestroyFX, this.transform.position, Quaternion.identity);
    }
}
