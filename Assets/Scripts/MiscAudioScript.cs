using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Miscellaneous sound effects script
/// </summary>
public class MiscAudioScript : MonoBehaviour
{
    public AudioClip menuSelectionSound;
    public AudioClip allDeathSound;
    public AudioClip nibbleDeathSound;
    public AudioSource thisAudio;
    //these variables are to prevent more and more of the parent object to be spawned
    private static MiscAudioScript thisScriptInstance;
    // Start is called before the first frame update
    void Start()
    {
        thisAudio = GetComponent<AudioSource>();
        //PlayMenuSound();

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
        thisAudio = GetComponent<AudioSource>();
        if (GameObject.FindGameObjectsWithTag("Misc Music").Length > 1)
        {
            Destroy(this.gameObject);
            Debug.Log("Destroyed!");
            PlayMenuSound();

        }
        else
        {
            thisAudio = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
            PlayMenuSound();

        }
        Debug.Log("Not Destroyed!");

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

    /// <summary>
    /// DEPRECATED: was used to countdown before destroying.
    /// </summary>
    /// <returns></returns>
    IEnumerable IWaitCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
    }
}
