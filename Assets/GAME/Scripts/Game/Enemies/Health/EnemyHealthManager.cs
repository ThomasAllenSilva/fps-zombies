public class EnemyHealthManager : Damageable
{
    protected override async void Die()
    {
        await System.Threading.Tasks.Task.Delay(500);
    }
}
