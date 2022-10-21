public static class PlayerGlobalGunManager
{
    public static bool PlayerIsAiming { get; private set; }

    public static bool PlayerIsShooting { get; private set; }

    public static void SetPlayerIsAimingToTrue()
    {
        PlayerIsAiming = true;
    }

    public static void SetPlayerIsAimingToFalse()
    {
        PlayerIsAiming = false;
    }

    public static void SetPlayerIsShootingToTrue()
    {
        PlayerIsShooting = true;
    }

    public static void SetPlayerIsShootingToFalse()
    {
        PlayerIsShooting = false;
    }
}
