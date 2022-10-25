using System;
using UnityEngine;


public abstract class Damageable : MonoBehaviour
{
    [field: SerializeField] public int MaxHealth { get; private set; }

    public int CurrentHealth { get; private set; }

    public bool IsAlive { get; private set; } = true;

    public event Action OnDie;

    protected virtual void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damageToTake)
    {
        CurrentHealth -= damageToTake;

        if(CurrentHealth <= 0)
        {
            Die();
            IsAlive = false;
            OnDie?.Invoke();
            return;
        }
    }

    protected abstract void Die();
}
