using UnityEngine;

public class PlayerGunChangeManager : MonoBehaviour
{
    private PlayerInputsManager _playerInputsManager;

    private PlayerGunController[] currentGunsInSlot = new PlayerGunController[6];

    private int currentActiveGunSlotIndex;

    private void Awake()
    {
        currentGunsInSlot = GetComponentsInChildren<PlayerGunController>();

        _playerInputsManager = GetComponentInParent<PlayerInputsManager>();

        _playerInputsManager.OnPlayerChangedWeaponSlotToZero += ChangeCurrentActiveGunToSlotZero;

        _playerInputsManager.OnPlayerChangedWeaponSlotToOne += ChangeCurrentActiveGunToSlotOne;
    }

    private void ChangeCurrentActiveGunToSlotZero()
    {
        if (currentActiveGunSlotIndex != 0)
        {
            currentGunsInSlot[currentActiveGunSlotIndex].DeactivateThisWeapon();
        }
       
        currentActiveGunSlotIndex = 0;


    }

    private void ChangeCurrentActiveGunToSlotOne()
    {
        if (currentActiveGunSlotIndex != 1)
        {
            currentGunsInSlot[currentActiveGunSlotIndex].DeactivateThisWeapon();
        }

        currentActiveGunSlotIndex = 1;


    }

    public void AddGunToSlot(int slot, PlayerGunController gunToAdd)
    {
        currentGunsInSlot[slot] = gunToAdd;
    }

    public void ChangeCurrentActiveWeapon()
    {
        currentGunsInSlot[currentActiveGunSlotIndex].gameObject.transform.parent.gameObject.SetActive(true);
    }
}
