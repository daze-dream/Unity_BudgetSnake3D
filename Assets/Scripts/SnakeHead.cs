using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{

    private GameObject mainSnakeManager;
    private Rigidbody myRB;
    public ParticleSystem headDestroyFX;
    public AudioClip bounceSound;
    public AudioClip nibbleGetSound;
    public AudioClip deathSound;
    private AudioSource thisSource;
    // Start is called before the first frame update
    void Start()
    {
        thisSource = GetComponent<AudioSource>();
        mainSnakeManager = GameObject.FindGameObjectWithTag("manager");
        myRB = GetComponent<Rigidbody>();
        //myRB.velocity = transform.forward;//new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("nibble"))
        {
            //this.transform.parent.GetComponent<SnakeMove>().AddSnakeSegment();
            this.transform.parent.GetComponent<SnakeMoveWithDestroyingBody>().AddSnakeSegment();
            GameObject.Find("GameManagerObj").GetComponent<GameManager>().UpdateScore();
            thisSource.PlayOneShot(nibbleGetSound, .7f);
            Debug.Log("Hit Nibble");
        }
        if(collision.gameObject.CompareTag("bounce_enemy"))
        {
            Debug.Log("HEAD HIT ENEMY. GAME OVER");
            Instantiate(headDestroyFX, this.transform.position, this.transform.rotation);
            GameObject.Find("MiscSoundObj").GetComponent<MiscAudioScript>().PlayAllDeathSound();
            mainSnakeManager.GetComponent<SnakeMoveWithDestroyingBody>().DestroyAllSegments();
            GameObject.Find("GameManagerObj").GetComponent<GameManager>().GameOver();
        }
        if(collision.collider.tag == "wall")
        {
            //bounce method basically
            float curSpeed = mainSnakeManager.GetComponent<SnakeMove>().speed;
            Debug.Log("Object Up: " + transform.up + " || object Quarternion:  " + transform.rotation + "|| normal of collison: " + collision.GetContact(0).normal);
            var direction = Vector3.Reflect(transform.forward, collision.GetContact(0).normal);
            var rot = Quaternion.FromToRotation(transform.forward, direction);
            Debug.Log("Reflection Quarternion: " + rot);
            transform.rotation *= new Quaternion(0, (rot.y == 0 ? 1 : rot.y), 0, rot.w);
            thisSource.PlayOneShot(bounceSound, .7f);
            //transform.rotation *= rot;
        }
    }

}
