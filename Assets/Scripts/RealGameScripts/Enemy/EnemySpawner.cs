using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> spawnPoints;
    public List<GameObject> enemyPrefabs;
    public float spawnRate = 1f;
    public bool canSpawn = true;
    void Start()
    {
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

    GameObject randomEnemyPrefabs()
    {
        int number = Random.Range(0, enemyPrefabs.Count);
        return enemyPrefabs[number];
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while(true)
        {
            yield return wait;
            Spawn();
        }
    }

    void Spawn()
    {
        Instantiate(randomEnemyPrefabs(), randomSpawnPoint(), Quaternion.identity);
    }
}
