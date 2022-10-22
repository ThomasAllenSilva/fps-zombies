using UnityEngine;

[RequireComponent(typeof(PlayerGunController))]

public class PlayerGunAnimationManager : CharacterAnimationController
{
    [SerializeField] private AnimationClip _reloadGunAnimation;

    [Range(1f, 12f)] [SerializeField] private float _animationsTransitionSpeed = 4f;

    private PlayerGunController _playerGunController;

    private GunAnimationStates _currentAnimationState = GunAnimationStates.Gun_Draw;

    private const float RunAnimationFloatValue = 1f;

    private const float WalkAnimationFloatValue = 1.5f;

    private const float IdleAnimationFloatValue = 2f;

    private const float ShootAnimationFloatValue = 3f;

    private const string BlendTreeAnimationParameterName = "CurrentPlayerAnimationStateValue";

    private float blendTreeAnimationParameterValue = 2f;

    private bool _canPlayAnimations;

    protected override void Awake()
    {
        base.Awake();
        _playerGunController = GetComponent<PlayerGunController>();
    }

    private void LateUpdate()
    {
        if (!_canPlayAnimations)
        {
            return;
        }

        if (PlayerIsReloading() && !PlayerIsShooting())
        {
            ChangeCurrentAnimationState(GunAnimationStates.Gun_Reload);
            return;
        }

        if (PlayerIsShooting() && !PlayerIsReloading())
        {
            ChangeBlendTreeAnimationParameterValueTo(ShootAnimationFloatValue);
            return;
        }

        if (!PlayerIsMoving())
        {
            ChangeBlendTreeAnimationParameterValueTo(IdleAnimationFloatValue);
            return;
        }

        if (PlayerIsRunning() && !PlayerGlobalGunManager.PlayerIsAiming)
        {
            ChangeBlendTreeAnimationParameterValueTo(RunAnimationFloatValue);
            return;
        }

        ChangeBlendTreeAnimationParameterValueTo(WalkAnimationFloatValue);
    }

    private bool PlayerIsRunning()
    {
        return _playerGunController.GetPlayerController().PlayerMovementManager.PlayerIsMovingInFowardDirecion && _playerGunController.GetPlayerController().PlayerMovementManager.PlayerIsRunning;
    }

    private bool PlayerIsMoving()
    {
        return _playerGunController.GetPlayerController().PlayerInputsManager.PlayerMovementValue() != Vector2.zero;
    }

    private bool PlayerIsShooting()
    {
        return _playerGunController.PlayerGunShootManager.PlayerIsShooting;
    }

    private bool PlayerIsReloading()
    {
        return _playerGunController.PlayerGunShootManager.PlayerIsReloading;
    }

    private void ChangeBlendTreeAnimationParameterValueTo(float targetValue)
    {
        if (blendTreeAnimationParameterValue != targetValue)
        {
            if (targetValue == ShootAnimationFloatValue) blendTreeAnimationParameterValue = ShootAnimationFloatValue;

            else blendTreeAnimationParameterValue = Mathf.MoveTowards(blendTreeAnimationParameterValue, targetValue, Time.deltaTime * _animationsTransitionSpeed);
        }

        _characterAnimator.SetFloat(BlendTreeAnimationParameterName, blendTreeAnimationParameterValue);

        ChangeCurrentAnimationState(GunAnimationStates.Gun_BlendTree);
    }

    private void PlayDrawGunAnimation()
    {
        ChangeCurrentAnimationState(GunAnimationStates.Gun_Draw);
    }

    private void ChangeCurrentAnimationState(GunAnimationStates animationToPlay)
    {
        if (animationToPlay == _currentAnimationState) return;

        _characterAnimator.Play(animationToPlay.ToString());

        _currentAnimationState = animationToPlay;
    }

    public float GetGunReloadAnimationTime()
    {
        return _reloadGunAnimation.length;
    }

    public void AllowPlayAnimations()
    {
        _canPlayAnimations = true;
    }

    private void OnEnable()
    {
        PlayDrawGunAnimation();
    }

    private void OnDisable()
    {
        _canPlayAnimations = false;
    }

    private enum GunAnimationStates
    {
        Gun_Draw,
        Gun_BlendTree,
        Gun_Reload,
        Gun_Inspect
    }
}
