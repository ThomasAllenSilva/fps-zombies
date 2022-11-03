using UnityEngine;

[RequireComponent(typeof(PlayerGunController))]

public class PlayerGunAnimationManager : CharacterAnimationController<PlayerGunAnimationManager.GunAnimationStates>
{
    [Range(1f, 12f)] [SerializeField] private float _animationsTransitionSpeed = 4f;

    [SerializeField] private AnimationClip _reloadGunAnimation;

    private PlayerGunController _playerGunController;

    private const string BlendTreeAnimationParameterName = "CurrentAnimationStateValue";

    private const float RunAnimationFloatValue = 1f;

    private const float WalkAnimationFloatValue = 1.5f;

    private const float IdleAnimationFloatValue = 2f;

    private const float ShootAnimationFloatValue = 3f;

    private float blendTreeAnimationParameterValue = 2f;

    protected override void Awake()
    {
        base.Awake();

        _canPlayAnimations = false;

        _playerGunController = GetComponent<PlayerGunController>();
    }

    private void LateUpdate()
    {
        if (!_canPlayAnimations)
        {
            return;
        }

        if (PlayerIsReloading())
        {
            ChangeCurrentAnimationState(GunAnimationStates.Gun_Reload);
            return;
        }

        if (PlayerIsShooting() && !PlayerIsReloading())
        {
            ChangeBlendTreeAnimationParameterValueTo(ShootAnimationFloatValue);
            return;
        }

        if (PlayerIsWalking())
        {
            ChangeBlendTreeAnimationParameterValueTo(WalkAnimationFloatValue);
            return;
        }

        if (PlayerIsRunning() && !PlayerGlobalGunManager.PlayerIsAiming)
        {
            ChangeBlendTreeAnimationParameterValueTo(RunAnimationFloatValue);
            return;
        }

        ChangeBlendTreeAnimationParameterValueTo(IdleAnimationFloatValue);
    }

    private bool PlayerIsRunning()
    {
        return _playerGunController.GetPlayerController().PlayerMovementManager.PlayerIsMovingInFowardDirecion && _playerGunController.GetPlayerController().PlayerMovementManager.PlayerIsRunning;
    }

    private bool PlayerIsWalking()
    {
        return _playerGunController.GetPlayerController().PlayerInputsManager.PlayerMovementValue() != Vector2.zero && !_playerGunController.GetPlayerController().PlayerMovementManager.PlayerIsRunning;
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
        ChangeCurrentAnimationState(GunAnimationStates.Gun_BlendTree);

        if (blendTreeAnimationParameterValue == targetValue)
        {
            return;
        }

        if (targetValue == ShootAnimationFloatValue)
        {
            _characterAnimator.SetFloat(BlendTreeAnimationParameterName, blendTreeAnimationParameterValue = ShootAnimationFloatValue);

            return;
        }

        blendTreeAnimationParameterValue = Mathf.MoveTowards(blendTreeAnimationParameterValue, targetValue, Time.deltaTime * _animationsTransitionSpeed);

        _characterAnimator.SetFloat(BlendTreeAnimationParameterName, blendTreeAnimationParameterValue);
    }

    public void PlayDrawGunAnimation()
    {
        ChangeCurrentAnimationState(GunAnimationStates.Gun_Draw);
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

    public enum GunAnimationStates
    {
        Gun_Draw,
        Gun_BlendTree,
        Gun_Reload,
        Gun_Hide,
        Gun_Inspect
    }

    public void PlayHideGunAnimation()
    {
        _canPlayAnimations = false;
        ChangeCurrentAnimationState(GunAnimationStates.Gun_Hide);
    }
}
