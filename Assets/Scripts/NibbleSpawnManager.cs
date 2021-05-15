using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NibbleSpawnManager : MonoBehaviour
{
    public GameObject nibblePrefab;
    public int nibbleCount = 1;

    public float xRange, zRange, checkRadius = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        xRange = GameObject.Find("Field").GetComponent<Collider>().bounds.size.x;
        zRange = GameObject.Find("Field").GetComponent<Collider>().bounds.size.z;
    }

    // Update is called once per frame
    void Update()
    {
        //if(GameObject.FindGameObjectsWithTag("nibble").Length == 0)
        //{
        //    SpawnNibble(nibbleCount);
        //}
    }
    private Vector3 GenerateSpawnPos()
    {
        bool isValidSpawn = false;
        float spawnX = 0.0f, spawnZ = 0.0f;
        while (!isValidSpawn)
        {
            spawnX = Random.Range(-Mathf.Floor((xRange / 2) - 1), Mathf.Floor((xRange / 2) - 1));
            spawnZ = Random.Range(-Mathf.Floor((zRange / 2) - 1), Mathf.Floor((zRange / 2) - 1));
            isValidSpawn = true;
            Collider[] localColliders = Physics.OverlapSphere(new Vector3(spawnX, 1, spawnZ), checkRadius);
            foreach(Collider l in localColliders)
            {
                if(l.tag == "wall")
                {
                    Debug.Log("Nibble Spawn not correct at x: " + spawnX + " Z: " + spawnZ);
                    isValidSpawn = false;
                }
            }

        }

        return new Vector3(spawnX,1, spawnZ);

    }

    void SpawnNibble(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            Instantiate(nibblePrefab, GenerateSpawnPos(), nibblePrefab.transform.rotation);
        }
    }

    public IEnumerator ISpawnEnumerator()
    {
        while (GameObject.Find("GameManagerObj").GetComponent<GameManager>().GAMEACTIVE == true)
        {
            if (GameObject.FindGameObjectsWithTag("nibble").Length == 0)
            {
                SpawnNibble(nibbleCount);
            }
            yield return null;
        }
    }


}
