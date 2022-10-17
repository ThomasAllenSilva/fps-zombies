using UnityEngine;

[RequireComponent(typeof(PlayerGunController))]

public class PlayerGunAnimationManager : MonoBehaviour
{
    [SerializeField] private AnimationClip _reloadGunAnimationState;

    private PlayerGunController _playerGunController;

    private Animator _playerGunAnimator;

    private GunAnimationStates _currentAnimationState = GunAnimationStates.Gun_Draw;

    private void Awake()
    {
        _playerGunAnimator = GetComponent<Animator>();
        _playerGunController = GetComponent<PlayerGunController>();
    }

    private void Start()
    {
        _playerGunController.PlayerGunShootManager.OnPlayerStartReloading += PlayReloadGunAnimation;
        _playerGunController.PlayerController.PlayerInputsManager.OnIsPressingShootButton += PlayShootingGunAnimation;
    }

    private void PlayReloadGunAnimation()
    {
        ChangeCurrentAnimationState(GunAnimationStates.Gun_Reload);
    }
    private void PlayShootingGunAnimation()
    {
        ChangeCurrentAnimationState(GunAnimationStates.Gun_Shoot);
    }

    private void ChangeCurrentAnimationState(GunAnimationStates animationToPlay)
    {
        if (animationToPlay == _currentAnimationState) return;

        _playerGunAnimator.Play(animationToPlay.ToString());

        _currentAnimationState = animationToPlay;
    }

    public float GetGunReloadAnimationTime()
    {
        return _reloadGunAnimationState.length;
    }

    private enum GunAnimationStates 
    {
        Gun_Draw,
        Gun_Reload,
        Gun_Shoot
    }
}
