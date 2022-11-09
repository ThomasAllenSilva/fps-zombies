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
        _enemyController.EnemyHealthManager.OnDie += PlayDieAnimation;

        _enemyController.EnemyCollisionsManager.OnPlayerEnteredAttackTrigger += PlayAttackAnimation;

        _enemyController.EnemyCollisionsManager.OnPlayerLeftAttackTrigger += PlayRunAnimation;

        ChangeCurrentAnimationState(EnemyAnimationsStates.EnemyRun);
    }

    private void PlayDieAnimation()
    {
        ChangeCurrentAnimationState(EnemyAnimationsStates.EnemyDie);

        _canPlayAnimations = false;
    }


    private void PlayRunAnimation()
    {
        ChangeCurrentAnimationState(EnemyAnimationsStates.EnemyRun);
    }

    private void PlayAttackAnimation()
    {
        ChangeCurrentAnimationState(EnemyAnimationsStates.EnemyAttack);
    }

    public void DisableAnimator()
    {
        _characterAnimator.enabled = false;
    }

    private void EnableAnimator()
    {
        _characterAnimator.enabled = true;
    }

    private void OnEnable()
    {
        EnableAnimator();
    }
}
