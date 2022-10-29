using System;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyCollisionsManager : MonoBehaviour
{
    private static readonly string _playerTag = "Player";

    public event Action OnPlayerEnteredAttackTrigger;

    public event Action OnPlayerLeftAttackTrigger;

    private EnemyHealthManager _enemyHealthManager;

    private bool _isAllowedToCheckTrigger = true;

    private void Awake()
    {
        _enemyHealthManager = transform.parent.GetComponent<EnemyController>().EnemyHealthManager;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!_enemyHealthManager.IsAlive || !_isAllowedToCheckTrigger)
        {
            return;
        }

        if (other.gameObject.CompareTag(_playerTag))
        {
            OnPlayerEnteredAttackTrigger?.Invoke();
            _isAllowedToCheckTrigger = false;
            AllowCheckTriggerAgain();
        }
    }

    private async void AllowCheckTriggerAgain()
    {
        await Task.Delay(500);
        _isAllowedToCheckTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_enemyHealthManager.IsAlive)
        {
            return;
        }

        if (other.gameObject.CompareTag(_playerTag))
        {
            OnPlayerLeftAttackTrigger?.Invoke();
        }
    }

    private void OnDestroy()
    {
        OnPlayerEnteredAttackTrigger = delegate { };
    }
}
