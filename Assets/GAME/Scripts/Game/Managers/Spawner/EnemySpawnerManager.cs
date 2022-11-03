using System.Collections;
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
        yield return new WaitForSecondsRealtime(spawnDelay);

        while (true)
        {
            TypesOfEnemies randomEnemy = (TypesOfEnemies)Random.Range(0, 3);

            if (currentAmountOfEnemiesInGame < maxEnemiesInGame)
            {
                bool spawnedSuccessfully = ObjectsPoolerManager.Instance.SpawnObjectFromPool(randomEnemy.ToString(), transform.TransformPoint(transform.localPosition), transform.rotation);

                if (spawnedSuccessfully)
                {
                    currentAmountOfEnemiesInGame++;
                }
            }

            yield return new WaitForSecondsRealtime(spawnDelay);
        }
    }

    private enum TypesOfEnemies 
    {
        EnemyTypeOne,

        EnemyTypeTwo,

        EnemyTypeThree
    }
}
