using UnityEngine;

public class PlayerInputsManager : MonoBehaviour
{

    private PlayerInputsActions _playerInputActions;

    private void Awake() => _playerInputActions = new PlayerInputsActions();

    public Vector2 PlayerMovementValue()
    {
        return _playerInputActions.Player.Movement.ReadValue<Vector2>();
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
