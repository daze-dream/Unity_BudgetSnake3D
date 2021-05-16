using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscAudioScript : MonoBehaviour
{
    public AudioClip menuSelectionSound;
    public AudioClip allDeathSound;
    public AudioClip nibbleDeathSound;
    public AudioSource thisAudio;
    // Start is called before the first frame update
    void Start()
    {
        thisAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
