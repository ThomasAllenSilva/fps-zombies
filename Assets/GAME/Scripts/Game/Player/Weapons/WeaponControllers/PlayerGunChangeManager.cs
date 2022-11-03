using UnityEngine;

public class PlayerGunChangeManager : MonoBehaviour
{
    [Min(0.4f)]
    [SerializeField] private float _delayToChangeWeapon;

    private PlayerInputsManager _playerInputsManager;

    private PlayerGunController[] _currentGunsInSlot = new PlayerGunController[6];

    private int _currentActiveGunSlotIndex;

    private bool _playerIsReadyToChangeWeapon = true;

    private void Awake()
    {
        _currentGunsInSlot = GetComponentsInChildren<PlayerGunController>(true);

        _playerInputsManager = GetComponentInParent<PlayerInputsManager>();

        _playerInputsManager.OnPlayerChangedWeaponSlotToZero += ChangeCurrentActiveGunToSlotZero;

        _playerInputsManager.OnPlayerChangedWeaponSlotToOne += ChangeCurrentActiveGunToSlotOne;

        foreach (PlayerGunController gun in _currentGunsInSlot)
        {
            AddGunToSlot(gun.transform.parent.GetSiblingIndex(), gun);
        }
    }

    private void ChangeCurrentActiveGunToSlotZero()
    {
        if (!CheckIfPlayerCanChangeWeapon() || _currentActiveGunSlotIndex == 0 )
        {
            return;
        }

        _playerIsReadyToChangeWeapon = false;
        _currentGunsInSlot[_currentActiveGunSlotIndex].DeactivateThisWeapon();

        _currentActiveGunSlotIndex = 0;

        ChangeCurrentActiveWeapon();

        Invoke(nameof(AllowPlayerChangeWeaponAgain), _delayToChangeWeapon);
    }

    private void ChangeCurrentActiveGunToSlotOne()
    {
        if (!CheckIfPlayerCanChangeWeapon() || _currentActiveGunSlotIndex == 1)
        {
            return;
        }

        _playerIsReadyToChangeWeapon = false;
        _currentGunsInSlot[_currentActiveGunSlotIndex].DeactivateThisWeapon();

        _currentActiveGunSlotIndex = 1;

        ChangeCurrentActiveWeapon();

        Invoke(nameof(AllowPlayerChangeWeaponAgain), _delayToChangeWeapon);
    }

    private bool CheckIfPlayerCanChangeWeapon()
    {
        return _playerIsReadyToChangeWeapon && !PlayerGlobalGunManager.PlayerIsReloading;
    }

    public void AddGunToSlot(int slot, PlayerGunController gunToAdd)
    {
        _currentGunsInSlot[slot] = gunToAdd;
    }

    public void ChangeCurrentActiveWeapon()
    {
        _currentGunsInSlot[_currentActiveGunSlotIndex].ActivateThisWeapon();
    }

    private void AllowPlayerChangeWeaponAgain()
    {
        _playerIsReadyToChangeWeapon = true;
    }
}
