using UnityEngine;

[RequireComponent(typeof(PlayerGunController))]

public class PlayerGunAnimationManager : MonoBehaviour
{
    [SerializeField] private AnimationClip _reloadGunAnimation;

    private PlayerGunController _playerGunController;

    private Animator _playerGunAnimator;

    private GunAnimationStates _currentAnimationState = GunAnimationStates.Gun_Draw;

    private bool _canPlayAnimations;

    private void Awake()
    {
        _playerGunAnimator = GetComponent<Animator>();
        _playerGunController = GetComponent<PlayerGunController>();
    }

    private void LateUpdate()
    {
        if (_canPlayAnimations)
        {
            if (!PlayerIsShooting() && !PlayerIsReloading())
            {
                if (PlayerIsMoving())
                {
                    if (PlayerIsRunning())
                    {
                        PlayRunningGunAnimation();
                    }

                    else
                    {
                        PlayWalkingGunAnimation();
                    }
                }

                else
                {
                    PlayIdleGunAnimation();
                }
            }

            else
            {
                if (PlayerIsShooting() && !PlayerIsReloading())
                {
                    PlayShootingGunAnimation();
                }

                else if (PlayerIsReloading())
                {
                    PlayReloadGunAnimation();
                }
            }
        }
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

    private void PlayReloadGunAnimation()
    {
        ChangeCurrentAnimationState(GunAnimationStates.Gun_Reload);
    }

    private void PlayShootingGunAnimation()
    {
        ChangeCurrentAnimationState(GunAnimationStates.Gun_Shoot);
    }

    private void PlayWalkingGunAnimation()
    {
        ChangeCurrentAnimationState(GunAnimationStates.Gun_Walk);
    }

    private void PlayRunningGunAnimation()
    {
        ChangeCurrentAnimationState(GunAnimationStates.Gun_Run);
    }

    private void PlayIdleGunAnimation()
    {
        ChangeCurrentAnimationState(GunAnimationStates.Gun_Idle);
    }

    private void PlayDrawGunAnimation()
    {
        ChangeCurrentAnimationState(GunAnimationStates.Gun_Draw);
    }

    private void ChangeCurrentAnimationState(GunAnimationStates animationToPlay)
    {
        if (animationToPlay == _currentAnimationState) return;

        _playerGunAnimator.Play(animationToPlay.ToString());

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
        Gun_Idle,
        Gun_Walk,
        Gun_Run,
        Gun_Shoot,
        Gun_Reload,
        Gun_Inspect
    }
}
