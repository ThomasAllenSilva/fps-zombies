
public class EnemyAnimations : CharacterAnimationController<EnemyAnimations.EnemyAnimationsStates>
{
    private EnemyController _enemyController;

    public enum EnemyAnimationsStates { EnemyRun, EnemyDie, EnemyAttack }

    protected override void Awake()
    {
        base.Awake();
        _enemyController = GetComponent<EnemyController>();
    }

    private void Start()
    {
        _enemyController.EnemyCollisionsManager.OnPlayerEnteredAttackTrigger += PlayAttackAnimation;
        _enemyController.EnemyCollisionsManager.OnPlayerLeftAttackTrigger += PlayRunAnimation;
        _enemyController.EnemyHealthManager.OnDie += PlayDieAnimation;

        ChangeCurrentAnimationState(EnemyAnimationsStates.EnemyRun);
    }

    private void PlayDieAnimation()
    {
        ChangeCurrentAnimationState(EnemyAnimationsStates.EnemyDie);

        _canPlayAnimations = false;
    }

    public void DisableAnimator()
    {
        _characterAnimator.enabled = false;
    }

    private void PlayRunAnimation()
    {
        if(_canPlayAnimations)
        ChangeCurrentAnimationState(EnemyAnimationsStates.EnemyRun);
    }

    private void PlayAttackAnimation()
    {
        ChangeCurrentAnimationState(EnemyAnimationsStates.EnemyAttack);
    }
}
