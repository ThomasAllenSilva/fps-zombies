using UnityEngine;
using System.Collections.Generic;
using System;

public class PlayerGunChangeManager : MonoBehaviour
{
    private PlayerGunController[] _handGuns;

    private PlayerInputsManager _playerInputsManager;

    private List<PlayerGunController> currentGunsInSlot = new List<PlayerGunController>(); 

    private void Awake()
    {
        _handGuns = GetComponentsInChildren<PlayerGunController>();

        _playerInputsManager = GetComponentInParent<PlayerInputsManager>();

        _playerInputsManager.OnPlayerChangedWeaponSlotToOne += ChangeCurrentActiveGunToSlotOne;

        _playerInputsManager.OnPlayerChangedWeaponSlotToTwo += ChangeCurrentActiveGunToSlotTwo;
    }
    private void ChangeCurrentActiveGunToSlotOne()
    {
        currentGunsInSlot[0].DeactivateThisWeapon();
    }

    private void ChangeCurrentActiveGunToSlotTwo()
    {
       
    }

  

    public void AddGunToCurrentGunsInSlot(PlayerGunController gunToAdd)
    {
        currentGunsInSlot.Add(gunToAdd);
    }

    public void RemoveGunFromCurrentGunsInSlot(PlayerGunController gunToRemove)
    {
        currentGunsInSlot.Remove(gunToRemove);
    }
}
