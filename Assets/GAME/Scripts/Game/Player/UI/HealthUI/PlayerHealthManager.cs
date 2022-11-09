using System;

public class PlayerHealthManager : Damageable
{
    public event Action OnTakeDamage;

    public override void TakeDamage(int damageToTake)
    {
        
        base.TakeDamage(damageToTake);
        OnTakeDamage?.Invoke();
    }

    protected override void Die()
    {
        
    }
}
