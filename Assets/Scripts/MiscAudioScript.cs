using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscAudioScript : MonoBehaviour
{
    public AudioClip menuSelectionSound;
    public AudioClip allDeathSound;
    public AudioClip nibbleDeathSound;
    public AudioSource thisAudio;
    //these variables are to prevent more and more of the parent object to be spawned
    private GameObject[] other;
    bool NOTFIRST = false;
    // Start is called before the first frame update

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        thisAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// this is to prevent multiple parent objs spawning on scene load. Deletes the old one.
    /// </summary>
    private void Awake()
    {
        //find all objects in the scene of that tag
        other = GameObject.FindGameObjectsWithTag("Misc Music");
        //iterate through
        foreach (GameObject oneOther in other)
        {
            //if this object is not the first one in the build index...
            if (oneOther.scene.buildIndex == -1)
            {
                //means its the old one
                NOTFIRST = true;
            }
        }
        //so destroy it
        if (NOTFIRST == true)
        {
            Destroy(gameObject);
        }
        //posterity code
        DontDestroyOnLoad(gameObject);
        thisAudio = GetComponent<AudioSource>();
    }

    public void PlayMenuSound()
    {
        thisAudio.PlayOneShot(menuSelectionSound, 1.0f);
    }

    public void PlayAllDeathSound()
    {
        thisAudio.PlayOneShot(allDeathSound, 1.0f);

    }
    public void PlayNibbleDeathSound()
    {
        thisAudio.PlayOneShot(nibbleDeathSound, 1.0f);
    }
}
