using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyCollisionsManager EnemyCollisionsManager { get; private set; }

    public EnemyHealthManager EnemyHealthManager { get; private set; }

    public EnemyAttackManager EnemyAttackManager { get; private set; }

    private CapsuleCollider _capsuleCollider;

    private static GameManager _gameManager;
  
    private void Awake()
    {
        EnemyCollisionsManager = GetComponentInChildren<EnemyCollisionsManager>();

        EnemyHealthManager = GetComponent<EnemyHealthManager>();

        EnemyAttackManager = GetComponentInChildren<EnemyAttackManager>();

        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void Start()
    {
        EnemyHealthManager.OnDie += DisableCapsuleCollider;

        if (_gameManager == null)
        {
            _gameManager = GameManager.Instance;
        }
    }

    private void DisableCapsuleCollider()
    {
        _capsuleCollider.enabled = false;
    }

    private void EnableCapsuleCollider()
    {
        _capsuleCollider.enabled = true;
    }

    private void OnEnable()
    {
        EnableCapsuleCollider();
    }

    private void OnBecameInvisible()
    {
        if (!EnemyHealthManager.IsAlive)
        {
            gameObject.SetActive(false);

            _gameManager.EnemySpawnerManager.ReduceCountOfActiveEnemies();
        }
    }
}
