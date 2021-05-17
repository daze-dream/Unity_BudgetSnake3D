using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NibbleSpawnManager : MonoBehaviour
{
    public GameObject nibblePrefab;
    public int nibbleCount;

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
    /// <summary>
    /// This is supposed to spawn a random position based on the size of the field, 
    /// while checking the collision to see if it is valid aka not inside another object in a radius
    /// </summary>
    /// <returns>Vector3 in the area of the field</returns>
    private Vector3 GenerateSpawnPos()
    {
        bool isValidSpawn = false;
        float spawnX = 0.0f, spawnZ = 0.0f;
        while (!isValidSpawn)
        {
            spawnX = Random.Range(-Mathf.Floor((xRange / 2) - 1), Mathf.Floor((xRange / 2) - 1));
            spawnZ = Random.Range(-Mathf.Floor((zRange / 2) - 1), Mathf.Floor((zRange / 2) - 1));
            isValidSpawn = true;
            //checks a radius around the spawnpoint to prevent being stuck in something
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

    /// <summary>
    /// Spawns nibbles and you can set the amount.
    /// </summary>
    /// <param name="amount"></param>
    void SpawnNibble(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            Instantiate(nibblePrefab, GenerateSpawnPos(), nibblePrefab.transform.rotation);
        }
    }
    /// <summary>
    /// basically the above code but in a coroutine to be able to use in the GameManager. While there are no nibbles, spawn some.
    /// </summary>
    /// <returns></returns>
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
