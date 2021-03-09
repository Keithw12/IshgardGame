using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    public GameObject Enemy;
    public int[] xSpawnPositions = new int[5];
    public int[] zSpawnPositions = new int[5];
    public int numOfEnemies;
    public float timeBetweenSpawns;

    public bool gameOverState = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(EnemySpawn());
    }

    // Update is called once per frame
    IEnumerator EnemySpawn()
    {
        while (numOfEnemies < 5)
        {

            int i = Random.Range(0, 5);



              
            Instantiate(Enemy, new Vector3(xSpawnPositions[i], 0f, zSpawnPositions[i]), Quaternion.identity);

            yield return new WaitForSeconds(timeBetweenSpawns);
            numOfEnemies += 1;

        }
    }
}
