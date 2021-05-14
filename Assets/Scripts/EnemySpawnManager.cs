using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GameObject tempEnemy;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
