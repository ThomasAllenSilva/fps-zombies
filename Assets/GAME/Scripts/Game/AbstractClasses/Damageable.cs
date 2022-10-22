using UnityEngine;


public abstract class Damageable : MonoBehaviour
{
    [field: SerializeField] public int MaxHealth { get; private set; }

    public int CurrentHealth { get; private set; }

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
        }

    }

    protected virtual void Die()
    {
        gameObject.SetActive(false);
    }
}
