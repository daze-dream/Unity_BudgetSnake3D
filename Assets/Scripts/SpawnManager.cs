using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject nibblePrefab;
    public int nibbleCount = 1;

    public float xRange, zRange;
    
    // Start is called before the first frame update
    void Start()
    {
        xRange = GameObject.Find("Field").GetComponent<Collider>().bounds.size.x;
        zRange = GameObject.Find("Field").GetComponent<Collider>().bounds.size.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("nibble").Length == 0)
        {
            SpawnNibble(3);
        }
    }
    private Vector3 GenerateSpawnPos()
    {
        float spawnX = Random.Range(-Mathf.Floor((xRange / 2) - 1), Mathf.Floor((xRange / 2)-1) );
        float spawnZ = Random.Range(-Mathf.Floor((zRange / 2) -1 ), Mathf.Floor((zRange / 2)-1) );
        return new Vector3(spawnX,1, spawnZ);

    }

    void SpawnNibble(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            Instantiate(nibblePrefab, GenerateSpawnPos(), nibblePrefab.transform.rotation);
        }
    }


}
