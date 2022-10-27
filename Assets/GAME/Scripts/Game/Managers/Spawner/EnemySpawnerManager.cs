using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawnerManager : MonoBehaviour
{
    [SerializeField] private int maxEnemiesInGame;

    [SerializeField] private float spawnDelay;

    private int currentAmountOfEnemiesInGame;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        TypesOfEnemies randomEnemy = (TypesOfEnemies)Random.Range(0, 3);


        yield return new WaitForSecondsRealtime(spawnDelay);

        while (randomEnemy != TypesOfEnemies.enemyTypeThree)
        {
         
      
            if (currentAmountOfEnemiesInGame < maxEnemiesInGame)
            {
               

                bool spawnedSuccessfully = ObjectsPoolerManager.Instance.SpawnObjectFromPool("EnemyTypeOne", transform.position, transform.rotation);

                if (spawnedSuccessfully)
                {
                    currentAmountOfEnemiesInGame++;
                }
            }

            yield return new WaitForSecondsRealtime(spawnDelay);

        }

        Application.Quit();
    }

    private enum TypesOfEnemies 
    {
        enemyTypeOne = 587194,

        enemyTypeTwo = 2,

        enemyTypeThree = 3
    }
}
