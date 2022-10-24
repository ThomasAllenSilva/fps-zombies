using System;
using UnityEngine;

public class EnemyCollisionsManager : MonoBehaviour
{
    private static readonly string _playerTag = "Player";

    public event Action OnPlayerEnteredAttackTrigger;

    public event Action OnPlayerLeftAttackTrigger;

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag(_playerTag))
        {
            return;
        }

        OnPlayerEnteredAttackTrigger?.Invoke();
    }


    private void OnTriggerExit(Collider other)
    {
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
