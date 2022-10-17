using System;
using UnityEngine;

public class PlayerInputsManager : MonoBehaviour
{
    private PlayerInputsActions _playerInputActions;

    public event Action OnIsPressingShootButton;
    public event Action OnStopPressingShootButton;
    public event Action OnPressedReloadButton;

    private void Awake()
    {
        _playerInputActions = new PlayerInputsActions();

        _playerInputActions.PlayerWeaponsController.Shoot.performed += _ => OnIsPressingShootButton?.Invoke();
        _playerInputActions.PlayerWeaponsController.Shoot.canceled += _ => OnStopPressingShootButton?.Invoke();

        _playerInputActions.PlayerWeaponsController.Reload.performed += _ => OnPressedReloadButton?.Invoke();
    }

    public Vector2 PlayerMovementValue()
    {
        return _playerInputActions.PlayerMovementController.Movement.ReadValue<Vector2>();
    }

    public Vector2 PlayerMouseDeltaValue()
    {
        return _playerInputActions.PlayerCameraController.Mouse.ReadValue<Vector2>();
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
