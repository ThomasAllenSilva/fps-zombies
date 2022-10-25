using UnityEngine;

public class EnemyAttackManager : MonoBehaviour
{
    [SerializeField] private int _hitDamage;

    [SerializeField] private float _knockBackForce;

    private static Damageable _playerDamageable;

    private static IKnockBack _playerKnockBack;

    private static readonly string _playerTag = "Player";

    private BoxCollider _attackCollider;

    private EnemyController _enemyController;


    private void Awake()
    {
        _attackCollider = GetComponent<BoxCollider>();

        _enemyController = GetComponentInParent<EnemyController>();

        if (_playerDamageable == null)
        {
            _playerDamageable = FindObjectOfType<EnemyHealthManager>();
        }

        if (_playerKnockBack == null)
        {
            _playerKnockBack = FindObjectOfType<PlayerKnockBackController>().GetComponent<IKnockBack>();
        }
    }

    private void Start()
    {
        _enemyController.EnemyCollisionsManager.OnPlayerLeftAttackTrigger += DisableAttackBoxCollider;
    }

    public void DisableAttackBoxCollider()
    {
        _attackCollider.enabled = false;
    }

    public void EnableAttackBoxCollider()
    {
        _attackCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_playerTag))
        {
            _playerDamageable.TakeDamage(_hitDamage);
            _playerKnockBack.PlayKnockBackEffect(transform.forward, _knockBackForce);
        }
    }
}
