using UnityEngine;

[RequireComponent(typeof(NavMeshTargetManager))]

public class EnemyController : MonoBehaviour
{
    public EnemyCollisionsManager EnemyCollisionsManager { get; private set; }

    public EnemyHealthManager EnemyHealthManager { get; private set; }

    public EnemyAttackManager EnemyAttackManager { get; private set; }

    private void Awake()
    {
        EnemyCollisionsManager = GetComponentInChildren<EnemyCollisionsManager>();

        EnemyHealthManager = GetComponent<EnemyHealthManager>();

        EnemyAttackManager = GetComponentInChildren<EnemyAttackManager>();
    }

    public void CallAttackFunction()
    {
        EnemyAttackManager.EnableAttackBoxCollider();
    }

    public void CallDisableAttackFunction()
    {
        EnemyAttackManager.DisableAttackBoxCollider();
    }
}
