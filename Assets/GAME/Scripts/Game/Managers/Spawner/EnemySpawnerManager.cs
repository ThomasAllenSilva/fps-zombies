using System.Collections;
using UnityEngine;


public class EnemySpawnerManager : MonoBehaviour
{
    [SerializeField] private int _maxActiveEnemiesShipsOnScreen;

    [SerializeField] private float _spawnDelay;

    [SerializeField] private Transform[] _spawnPositions;

    private SpriteRenderer[] _spawnersRenderers;

    private int currentAmountOfActiveEnemiesInGame;

    private GameManager _gameManager;

    private void Awake()
    {
        _spawnersRenderers = new SpriteRenderer[_spawnPositions.Length];

        for (int i = 0; i < _spawnPositions.Length; i++)
        {
            _spawnersRenderers[i] = _spawnPositions[i].GetComponent<SpriteRenderer>();
        }
    }

    private void Start()
    {
        _gameManager = GameManager.Instance;

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSecondsRealtime(_spawnDelay);

        while (true)
        {

            for (int i = currentAmountOfActiveEnemiesInGame; i < _maxActiveEnemiesShipsOnScreen; i++)
            {
                TypesOfEnemies randomEnemy = (TypesOfEnemies)Random.Range(0, 3);

                int randomSpawner = Random.Range(0, _spawnPositions.Length);


                bool spawnedSuccessfully = _gameManager.ObjectsPoolerManager.SpawnObjectFromPool(randomEnemy.ToString(), _spawnPositions[randomSpawner].position, _spawnPositions[randomSpawner].rotation);

                if (spawnedSuccessfully)
                {
                    currentAmountOfActiveEnemiesInGame++;
                }
            }

            yield return new WaitForSecondsRealtime(_spawnDelay);
        }
    }

    public void ReduceCountOfActiveEnemies()
    {
        currentAmountOfActiveEnemiesInGame -= 1;
    }

    private enum TypesOfEnemies 
    {
        EnemyTypeOne,

        EnemyTypeTwo,

        EnemyTypeThree
    }
}
