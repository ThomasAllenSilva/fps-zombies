using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackManager : MonoBehaviour
{
    private EnemyController _enemyController;

    private void Awake() => _enemyController = GetComponent<EnemyController>();

    private void Start()
    {
        _enemyController.EnemyCollisionsManager.OnTriggeredWithPlayer += AttackPlayer;
    }

    private void AttackPlayer()
    {

    }
}
