using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class NavMeshTargetManager : MonoBehaviour
{
    public static Transform TargetToFollow { get; private set; }

    private NavMeshAgent _enemyNavMeshAgent;

    private void Awake() => _enemyNavMeshAgent = GetComponent<NavMeshAgent>();

    private void Start()
    {
        if (TargetToFollow == null)
        {
            TargetToFollow = FindObjectOfType<PlayerController>().gameObject.transform;
        }
    }

    private void LateUpdate()
    {
        _enemyNavMeshAgent.SetDestination(TargetToFollow.position);
    }
}
