using System;

public static class PlayerGlobalGunManager
{
    public static bool PlayerIsAiming { get; private set; }

    public static bool PlayerIsHoldingShootButton { get; private set; }

    public static bool PlayerIsReloading { get; private set; }

    public static PlayerGunShootManager CurrentActiveGun { get; private set; }

    public static event Action OnChangedWeapon;

    public static void SetPlayerIsAimingToTrue()
    {
        PlayerIsAiming = true;
    }

    public static void SetPlayerIsAimingToFalse()
    {
        PlayerIsAiming = false;
    }

    public static void SetPlayerIsHoldingShootButtonToTrue()
    {
        PlayerIsHoldingShootButton = true;
    }

    public static void SetPlayerIsHoldingShootButtonToFalse()
    {
        PlayerIsHoldingShootButton = false;
    }

    public static void SetPlayerIsReloadingToTrue()
    {
        PlayerIsReloading = true;
    }

    public static void SetPlayerIsReloadingToFalse()
    {
        PlayerIsReloading = false;
    }

    public static void ChangeCurrentActiveGun(PlayerGunShootManager gunToSetActive)
    {
        CurrentActiveGun = gunToSetActive;
        OnChangedWeapon?.Invoke();
    }
}
