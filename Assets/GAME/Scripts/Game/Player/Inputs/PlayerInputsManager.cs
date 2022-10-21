using System;
using UnityEngine;

public class PlayerInputsManager : MonoBehaviour
{
    private PlayerInputsActions _playerInputActions;

    public event Action OnIsPressingShootButton;
    public event Action OnStoppedPressingShootButton;

    public event Action OnPressedReloadButton;

    public event Action OnPlayerIsPressingRunButton;
    public event Action OnPlayerStoppedPressingRunButton;

    public event Action OnPlayerIsPressingAimButton;
    public event Action OnPlayerStoppedPressingAimButtom;

    private void Awake()
    {
        _playerInputActions = new PlayerInputsActions();

        _playerInputActions.PlayerWeaponsController.Shoot.performed += _ => OnIsPressingShootButton?.Invoke();
        _playerInputActions.PlayerWeaponsController.Shoot.canceled += _ => OnStoppedPressingShootButton?.Invoke();

        _playerInputActions.PlayerWeaponsController.Aim.performed += _ => OnPlayerIsPressingAimButton?.Invoke();
        _playerInputActions.PlayerWeaponsController.Aim.canceled += _ => OnPlayerStoppedPressingAimButtom?.Invoke();

        _playerInputActions.PlayerWeaponsController.Reload.performed += _ => OnPressedReloadButton?.Invoke();

        _playerInputActions.PlayerMovementController.RunButton.performed += _ => OnPlayerIsPressingRunButton?.Invoke();
        _playerInputActions.PlayerMovementController.RunButton.canceled += _ => OnPlayerStoppedPressingRunButton?.Invoke();
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
}
