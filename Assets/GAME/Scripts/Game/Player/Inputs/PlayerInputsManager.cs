using System;
using UnityEngine;

public class PlayerInputsManager : MonoBehaviour
{
    private PlayerInputsActions _playerInputActions;

    public event Action OnPlayerIsPressingShootButton;
    public event Action OnPlayerStoppedPressingShootButton;

    public event Action OnPlayerPressedReloadButton;

    public event Action OnPlayerIsPressingRunButton;
    public event Action OnPlayerStoppedPressingRunButton;

    public event Action OnPlayerIsPressingAimButton;
    public event Action OnPlayerStoppedPressingAimButtom;

    public event Action OnPlayerChangedWeaponSlotToOne;
    public event Action OnPlayerChangedWeaponSlotToTwo;

    private void Awake()
    {
        _playerInputActions = new PlayerInputsActions();

        _playerInputActions.PlayerWeaponsController.Shoot.performed += _ => OnPlayerIsPressingShootButton?.Invoke();
        _playerInputActions.PlayerWeaponsController.Shoot.canceled += _ => OnPlayerStoppedPressingShootButton?.Invoke();

        _playerInputActions.PlayerWeaponsController.Aim.performed += _ => OnPlayerIsPressingAimButton?.Invoke();
        _playerInputActions.PlayerWeaponsController.Aim.canceled += _ => OnPlayerStoppedPressingAimButtom?.Invoke();

        _playerInputActions.PlayerWeaponsController.Reload.performed += _ => OnPlayerPressedReloadButton?.Invoke();

        _playerInputActions.PlayerMovementController.RunButton.performed += _ => OnPlayerIsPressingRunButton?.Invoke();
        _playerInputActions.PlayerMovementController.RunButton.canceled += _ => OnPlayerStoppedPressingRunButton?.Invoke();

        _playerInputActions.PlayerWeaponsController.WeaponSlotOne.performed += _ => OnPlayerChangedWeaponSlotToOne?.Invoke();
        _playerInputActions.PlayerWeaponsController.WeaponSlotTwo.performed += _ => OnPlayerChangedWeaponSlotToTwo?.Invoke();
    }

    public Vector2 PlayerMovementValue()
    {
        return _playerInputActions.PlayerMovementController.Movement.ReadValue<Vector2>();
    }

    public Vector2 PlayerMouseDeltaValue()
    {
        if (_playerInputActions != null)
        {
            return _playerInputActions.PlayerCameraController.Mouse.ReadValue<Vector2>();
        }

        return Vector2.zero;
    }

    private void OnEnable()
    {
        _playerInputActions.Enable();
    }

    private void OnDisable()
    {
        _playerInputActions.Disable();
    }

    private void RemoveAllListenersFromAllEvents()
    {
        OnPlayerPressedReloadButton = delegate { };
        OnPlayerStoppedPressingRunButton = delegate { };
        OnPlayerStoppedPressingShootButton = delegate { };
        OnPlayerIsPressingShootButton = delegate { };
        OnPlayerIsPressingRunButton = delegate { };
        OnPlayerIsPressingAimButton = delegate { };
        OnPlayerStoppedPressingAimButtom = delegate { };
    }

    private void OnDestroy()
    {
        RemoveAllListenersFromAllEvents();
    }
}
