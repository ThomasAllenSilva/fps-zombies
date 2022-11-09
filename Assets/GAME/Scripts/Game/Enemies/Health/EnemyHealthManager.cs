public class EnemyHealthManager : Damageable
{
    private EnemyController _enemyController;

    private static GameManager _gameManager;

    private void Awake()
    {
        _enemyController = GetComponent<EnemyController>();

        if (_gameManager == null)
        {
            _gameManager = GameManager.Instance;
        }
    }
    
    protected override void Die()
    {
        _gameManager.PlayerPointsManager.IncreasePlayerPoints(_enemyController.PointsFromThisEnemy);
    }

    private void OnEnable()
    {
        SetCurrentHealthToMaxHealth();
        SetIsAliveToTrue();
    }
}
