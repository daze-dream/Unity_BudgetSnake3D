using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Manages spawning the enemies based on difficulty, in set locations but random velocities.</summary>
public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GameObject tempEnemy;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// spawns enemies based on difficulty, in set locations
    /// </summary>
    /// <param name="difficulty"></param>
    public void SpawnEnemies(int difficulty)
    {
        switch (difficulty)
        {
            case 1:
                Instantiate(enemyPrefab, new Vector3(0, 1, -0.2f), enemyPrefab.transform.rotation).GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-4, 4), 0, 9);
                break;
            case 2:
                Instantiate(enemyPrefab, new Vector3(-14, 1, -0.2f), enemyPrefab.transform.rotation).GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-4, 4), 0, 9);
                Instantiate(enemyPrefab, new Vector3(14, 1, -0.2f), enemyPrefab.transform.rotation).GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-4, 4), 0, 9);
                break;
            case 3:
                Instantiate(enemyPrefab, new Vector3(-14, 1, -0.2f), enemyPrefab.transform.rotation).GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-4, 4), 0, 9);
                Instantiate(enemyPrefab, new Vector3(0, 1, -0.2f), enemyPrefab.transform.rotation).GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-4, 4), 0, 9);
                Instantiate(enemyPrefab, new Vector3(14, 1, -0.2f), enemyPrefab.transform.rotation).GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-4, 4), 0, 9);
                break;
            default:
                Instantiate(enemyPrefab, new Vector3(0, 1, -0.2f), enemyPrefab.transform.rotation).GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-4, 4), 0, 9);
                break;
        }

    }
}
