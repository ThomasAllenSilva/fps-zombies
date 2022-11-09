using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class NavMeshTargetManager : MonoBehaviour
{
    public static Transform TargetToFollow { get; private set; }

    private NavMeshAgent _enemyNavMeshAgent;

    private EnemyController _enemyController;

    private bool _canFollowTarget = true;

    private float _defaultNavMeshSpeed;

    private void Awake()
    {
        _enemyNavMeshAgent = GetComponent<NavMeshAgent>();
        _enemyController = GetComponent<EnemyController>();
    }

    private void Start()
    {
        if (TargetToFollow == null)
        {
            TargetToFollow = FindObjectOfType<PlayerController>().gameObject.transform;
        }

        _defaultNavMeshSpeed = _enemyNavMeshAgent.speed;

        _enemyController.EnemyHealthManager.OnDie += StopFollowingTarget;
    }

    private void LateUpdate()
    {
        if (!_canFollowTarget)
        {
            _enemyNavMeshAgent.speed = 0f;
            return;
        }

        _enemyNavMeshAgent.SetDestination(TargetToFollow.position);
        _enemyNavMeshAgent.speed = _defaultNavMeshSpeed;
    }


    private void StopFollowingTarget()
    {
        _canFollowTarget = false;
        _enemyNavMeshAgent.enabled = false;
    }

    private void OnEnable()
    {
        _enemyNavMeshAgent.enabled = true;
        _canFollowTarget = true;
    }
}
