using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class NavMeshTargetManager : MonoBehaviour
{
    public static Transform TargetToFollow { get; private set; }

    private NavMeshAgent _enemyNavMeshAgent;

    private EnemyController _enemyController;

    private bool _canFollowTarget = true;

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

        _enemyController.EnemyHealthManager.OnDie += StopFollowingTarget;
    }

    private void LateUpdate()
    {
        if (!_canFollowTarget)
        {
            _enemyNavMeshAgent.speed = 0;
            return;
        }

        _enemyNavMeshAgent.SetDestination(TargetToFollow.position);
    }


    private void StopFollowingTarget()
    {
        _canFollowTarget = false;
    }
}
