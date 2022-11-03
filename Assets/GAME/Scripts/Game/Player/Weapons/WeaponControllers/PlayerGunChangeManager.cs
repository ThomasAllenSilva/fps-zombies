using UnityEngine;

public class PlayerGunChangeManager : MonoBehaviour
{
    [SerializeField] private float _delayToChangeWeapon;

    private PlayerInputsManager _playerInputsManager;

    private PlayerGunController[] _currentGunsInSlot = new PlayerGunController[6];

    private int _currentActiveGunSlotIndex;

    private bool _canChangeWeapon = true;

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

    private void Start()
    {

    }

    private void ChangeCurrentActiveGunToSlotZero()
    {
        if (!_canChangeWeapon || _currentActiveGunSlotIndex == 0)
        {
            return;
        }

        _canChangeWeapon = false;
        _currentGunsInSlot[_currentActiveGunSlotIndex].DeactivateThisWeapon();

        _currentActiveGunSlotIndex = 0;

        ChangeCurrentActiveWeapon();

        Invoke(nameof(AllowPlayerChangeWeaponAgain), _delayToChangeWeapon);
    }

    private void ChangeCurrentActiveGunToSlotOne()
    {
        if (!_canChangeWeapon || _currentActiveGunSlotIndex == 1)
        {
            return;
        }

        _canChangeWeapon = false;
        _currentGunsInSlot[_currentActiveGunSlotIndex].DeactivateThisWeapon();

        _currentActiveGunSlotIndex = 1;

        ChangeCurrentActiveWeapon();

        Invoke(nameof(AllowPlayerChangeWeaponAgain), _delayToChangeWeapon);
    }

    public void AddGunToSlot(int slot, PlayerGunController gunToAdd)
    {
        _currentGunsInSlot[slot] = gunToAdd;
    }

    public void ChangeCurrentActiveWeapon()
    {
        _currentGunsInSlot[_currentActiveGunSlotIndex].gameObject.transform.parent.gameObject.SetActive(true);
        _currentGunsInSlot[_currentActiveGunSlotIndex].ActivateThisWeapon();
    }

    private void AllowPlayerChangeWeaponAgain()
    {
        _canChangeWeapon = true;
    }
}
