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
    public GameObject gameOverScreen; 
    public GameObject enemySpawnManager;
    public GameObject nibblesSpawnManager;
    public GameObject playerSnake;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(int difficulty)
    {
        //currentLength = 0;
        //maxLength = 0;
        GAMEACTIVE = true;
        titleScreen.SetActive(false);
        playerSnake.SetActive(true);
        enemySpawnManager.GetComponent<EnemySpawnManager>().SpawnEnemies(difficulty);
        StartCoroutine( nibblesSpawnManager.GetComponent<NibbleSpawnManager>().ISpawnEnumerator());

    }

    public void GameOver()
    {
        GAMEACTIVE = false;
        gameOverScreen.SetActive(true);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
