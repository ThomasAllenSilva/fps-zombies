using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    private static PlayerController _playerController;

    public bool PlayerIsHidingWeapon { get; private set; }

    public PlayerGunAnimationManager PlayerGunAnimationManager { get; private set; }

    public PlayerGunShootManager PlayerGunShootManager { get; private set; }

    private void Awake()
    {
        PlayerGunAnimationManager = GetComponent<PlayerGunAnimationManager>();

        PlayerGunShootManager = GetComponent<PlayerGunShootManager>();

        _playerController = GetComponentInParent<PlayerController>();
    }

    public PlayerController GetPlayerController()
    {
        return _playerController;
    }

    public void DeactivateThisWeapon()
    {
        SetPlayerIsHidingWeaponToTrue();
        PlayerGunAnimationManager.PlayHideGunAnimation();
    }

    public void ActivateThisWeapon()
    {
        transform.parent.gameObject.SetActive(true);
        PlayerGunAnimationManager.PlayDrawGunAnimation();
    }

    private void SetPlayerIsHidingWeaponToTrue()
    {
        PlayerIsHidingWeapon = true;
    }

    public void SetPlayerIsHidingWeaponToFalse()
    {
        PlayerIsHidingWeapon = false;
    }
}
