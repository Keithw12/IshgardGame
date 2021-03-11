using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    public GameObject Enemy;
    public int[] xSpawnPositions = new int[5];
    public int[] zSpawnPositions = new int[5];
    public int numOfEnemies = 0;
    public float timeBetweenSpawns;
    public int killedEnemies = 0;
    public int totalKilledEnemies = 0;
    public int maxEnemies = 5;
    public int waveNumber = 1;
    public float timeBetweenWaves;
    public bool gameOverState = false;
    
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(EnemySpawn());
    }
    void Update()
    {
        if(killedEnemies == maxEnemies)
        {
            waveNumber++;
            totalKilledEnemies += killedEnemies;
            killedEnemies = 0;
            numOfEnemies = 0;
            maxEnemies += 5;
            StartCoroutine(EnemySpawn());
            
        }

    }

    public void resetSpawner()
    {
        numOfEnemies = 0;
        killedEnemies = 0;
        totalKilledEnemies = 0;
        waveNumber = 1;
    }

    // Update is called once per frame
    IEnumerator EnemySpawn()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        while (numOfEnemies < maxEnemies && !gameOverState)
        {

            int i = Random.Range(0, 5);
                
            Instantiate(Enemy, new Vector3(xSpawnPositions[i], 0f, zSpawnPositions[i]), Quaternion.identity);

            yield return new WaitForSeconds(timeBetweenSpawns);
            numOfEnemies += 1;

        }
    }

    public void enemyKilled()
    {
        killedEnemies++;
    }
}
