using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerCharacterControllerManager : MonoBehaviour
{
    private CharacterController _playerCharacterController;

    private Vector3 _playerVelocity;

    private bool _playerIsGround;

    private readonly float _playerGravityValue = -9.81f;

    private void Awake() => _playerCharacterController = GetComponent<CharacterController>();

    private void Update()
    {
        _playerIsGround = _playerCharacterController.isGrounded; 

        if (_playerIsGround && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        _playerVelocity.y += _playerGravityValue * Time.deltaTime;
        _playerCharacterController.Move(_playerVelocity * Time.deltaTime);
    }

    public void MovePlayerToDirection(Vector3 directionPlayerShouldMove)
    {
        _playerCharacterController.Move(directionPlayerShouldMove * Time.deltaTime);
    }
}
