using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool GAMEACTIVE = false;
    public GameObject titleScreen;
    public GameObject inGameUI;
    public GameObject gameOverScreen; 
    public GameObject enemySpawnManager;
    public GameObject nibblesSpawnManager;
    public GameObject playerSnake;
    public GameObject directionalLight;
    public TextMeshProUGUI curLengthText;
    public TextMeshProUGUI longestLengthText;
    public AudioClip menuMusic, inGameMusic;
    private AudioSource backgroundMusicSource;
    public int curLengthValue, longestLengthValue;
    // Start is called before the first frame update
    void Start()
    {
        backgroundMusicSource = GetComponent<AudioSource>();
        backgroundMusicSource.clip = menuMusic;
        backgroundMusicSource.PlayDelayed(.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="addOrSub"></param>
    /// <param name="totalLength"></param>
    public void UpdateScore()
    {
        int x = playerSnake.GetComponent<SnakeMoveWithDestroyingBody>().bodyParts.Count - 1;
        if ( x > longestLengthValue)
        {
            longestLengthValue = x;
            longestLengthText.text = "Longest: " + longestLengthValue;
        };
        //curLengthText.text = "Current Length: " + curLengthValue;
        curLengthText.text = "Current Length: " + x;

    }

    public void StartGame(int difficulty)
    {
        //currentLength = 0;
        //maxLength = 0;
        GAMEACTIVE = true;
        titleScreen.SetActive(false);
        inGameUI.SetActive(true);
        playerSnake.SetActive(true);
        directionalLight.SetActive(true);
        enemySpawnManager.GetComponent<EnemySpawnManager>().SpawnEnemies(difficulty);
        StartCoroutine( nibblesSpawnManager.GetComponent<NibbleSpawnManager>().ISpawnEnumerator());
        curLengthValue = 0;
        longestLengthValue = 0;
        UpdateScore();
        backgroundMusicSource.Stop();
        backgroundMusicSource.clip = inGameMusic;
        backgroundMusicSource.PlayDelayed(.5f);


    }

    public void GameOver()
    {
        GAMEACTIVE = false;
        gameOverScreen.SetActive(true);
        directionalLight.SetActive(false);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
