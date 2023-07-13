using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public List<GameObject> spawnPoints;
    public List<GameObject> cloudPrefabs;
    public float spawnRate;
    public bool canSpawn = true;
    void Start()
    {
        Spawn();
        StartCoroutine(Spawner());
    }
    void Update()
    {

    }

    Vector3 randomSpawnPoint()
    {
        int number = Random.Range(0, spawnPoints.Count);
        return spawnPoints[number].GetComponent<Transform>().position;
    }

    GameObject randomCloudPrefabs()
    {
        int number = Random.Range(0, cloudPrefabs.Count);
        return cloudPrefabs[number];
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (true)
        {
            yield return wait;
            Spawn();
        }
    }

    void Spawn()
    {
        Instantiate(randomCloudPrefabs(), randomSpawnPoint(), Quaternion.identity);
    }
}
