using System;
using UnityEngine;

public class EnemyCollisionsManager : MonoBehaviour
{
    private static readonly string _playerTag = "Player";

    public event Action OnTriggeredWithPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_playerTag))
        {
            OnTriggeredWithPlayer?.Invoke();
            //other.gameObject.GetComponent<Damageable>().TakeDamage(100);
        }
    }

    private void OnDestroy()
    {
        OnTriggeredWithPlayer = delegate { };
    }
}
