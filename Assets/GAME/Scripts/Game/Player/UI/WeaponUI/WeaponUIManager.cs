using UnityEngine;
using TMPro;

public class WeaponUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentAmmoText;

    [SerializeField] private TextMeshProUGUI magazineAmmoText;

    [SerializeField] private PlayerInputsManager _playerInputsManager;

    [SerializeField] private PlayerGunShootManager _playerGunShootManager;

    private void Start()
    {
        PlayerGunShootManager.OnPlayerIsShooting += UpdateCurrentAmmoText;

        PlayerGunShootManager.OnPlayerStartedReloading += ResetCurrentAmmoText;

        PlayerGunShootManager.OnPlayerStartedReloading += UpdateWeaponLeftAmmo;

        PlayerGunShootManager.OnPlayerFinishedReloading += UpdateMagazineAmmo;

        PlayerGunShootManager.OnPlayerFinishedReloading += UpdateCurrentAmmoText;

        PlayerGlobalGunManager.OnChangedWeapon += UpdateAllValues;

        UpdateMagazineAmmo();
    }

    private void ResetCurrentAmmoText()
    {
        currentAmmoText.text = "0";
    }

    private void UpdateWeaponLeftAmmo()
    {
        magazineAmmoText.text = (PlayerGlobalGunManager.CurrentActiveGun.BulletsLeft + PlayerGlobalGunManager.CurrentActiveGun.MaxBullets).ToString();
    }

    private void UpdateMagazineAmmo()
    {
        magazineAmmoText.text = PlayerGlobalGunManager.CurrentActiveGun.MaxBullets.ToString();

    }

    private void UpdateCurrentAmmoText()
    {
        currentAmmoText.text = PlayerGlobalGunManager.CurrentActiveGun.BulletsLeft.ToString();
    }

    private void UpdateAllValues()
    {
        UpdateMagazineAmmo();
        UpdateCurrentAmmoText();
    }
}
