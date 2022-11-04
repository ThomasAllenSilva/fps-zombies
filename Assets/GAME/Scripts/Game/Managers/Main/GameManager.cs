public class GameManager : Singleton<GameManager>
{
    public ObjectsPoolerManager ObjectsPoolerManager { get; private set; }

    public EnemySpawnerManager EnemySpawnerManager { get; private set; }

    protected override void Awake()
    {
        base.Awake(); 

        ObjectsPoolerManager = GetComponentInChildren<ObjectsPoolerManager>();

        EnemySpawnerManager = GetComponentInChildren<EnemySpawnerManager>();
    }
}
