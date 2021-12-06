using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SpawnManager : NetworkBehaviour
{
    public GameObject ghost;
    public int spawnTime = 0;
    public List<GameObject> spawnPoint;


    void Start()
    {
        spawnTime = Random.Range(1, 3);
        StartCoroutine(SpawnGhost());
    }

    void Spawn()
    {
        int spawnChoice = Random.Range(0, spawnPoint.Count);
        Instantiate(ghost, spawnPoint[spawnChoice].transform.position, Quaternion.identity);
    }

    IEnumerator SpawnGhost()
    {
        Spawn();
        yield return new WaitForSeconds(spawnTime);

        StartCoroutine(SpawnGhost());
    }
}
