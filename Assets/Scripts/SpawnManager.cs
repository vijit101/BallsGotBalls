using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab,powerUpPrefab;
    public static List<Enemy> enemyList = new List<Enemy>();
    private float spawnRange = 9.0f;
    private int enemyWaveNumber = 1;

    private void Update()
    {
        if (enemyList.Count == 0)
        {            
            SpawnEnemyWave(enemyWaveNumber);
            SpawnPowerUpWave(enemyWaveNumber - 1);
            enemyWaveNumber++;
        }
    }

    public void SpawnEnemyWave(int spawnEnemyNumber)
    {
        for (int i = 0; i < spawnEnemyNumber; i++)
        {
            GameObject enemyGmo =  Instantiate(enemyPrefab, GetRandomSpawnPosition(), enemyPrefab.transform.rotation);
            enemyList.Add(enemyGmo.GetComponent<Enemy>());
        }
    }
    public void SpawnPowerUpWave(int spawnPowerNumber)
    {
        for (int i = 0; i < spawnPowerNumber; i++)
        {
            GameObject powerUpGmo = Instantiate(powerUpPrefab, GetRandomSpawnPosition(), enemyPrefab.transform.rotation);           
        }
    }
    Vector3 GetRandomSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
