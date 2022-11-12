using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private PlayerHealthManager _playerHealthManager;

    public event Action OnGameEnds;

    public ObjectsPoolerManager ObjectsPoolerManager { get; private set; }

    public EnemySpawnerManager EnemySpawnerManager { get; private set; }

    public PlayerPointsManager PlayerPointsManager { get; private set; }

    public AudioManager AudioManager { get; private set; }
    protected override void Awake()
    {
        base.Awake(); 

        ObjectsPoolerManager = GetComponentInChildren<ObjectsPoolerManager>();

        EnemySpawnerManager = GetComponentInChildren<EnemySpawnerManager>();

        PlayerPointsManager = GetComponentInChildren<PlayerPointsManager>();

        AudioManager = GetComponentInChildren<AudioManager>();
    }

    private void Start()
    {
        _playerHealthManager.OnDie += EndGame;
    }

    private void EndGame()
    {
        OnGameEnds?.Invoke();
    }
}
