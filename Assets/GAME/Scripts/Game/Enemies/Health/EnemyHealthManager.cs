using System;

public class EnemyHealthManager : Damageable
{
    public event Action OnDie;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Die()
    {
        base.Die();
        OnDie?.Invoke();
    }
}
