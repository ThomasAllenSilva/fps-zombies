using UnityEngine;

public class EnemyAnimationsEvents : MonoBehaviour
{
    private EnemyAttackManager _enemyAttackManager;

    private void Awake()
    {
        _enemyAttackManager = GetComponent<EnemyController>().EnemyAttackManager;    
    }

    public void CallAttackFunction()
    {
        _enemyAttackManager.EnableAttackBoxCollider();
    }

    public void CallDisableAttackFunction()
    {
        _enemyAttackManager.DisableAttackBoxCollider();
    }
}
