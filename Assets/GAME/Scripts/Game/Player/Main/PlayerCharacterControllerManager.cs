using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class PlayerCharacterControllerManager : MonoBehaviour
{
    private CharacterController _playerCharacterController;

    private Vector3 _playerVelocity;

    private bool _playerIsGround;

    private readonly float _playerGravityValue = -12f;

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

    public void MovePlayerToDirectionInstantly(Vector3 directionPlayerShouldMove)
    {
        _playerCharacterController.Move(directionPlayerShouldMove * Time.deltaTime);
    }

    public IEnumerator MovePlayerTowardsDirectionWhileIsInTime(Vector3 directionPlayerShouldMove, float amountOfTime)
    {
        float time = 0f;

        while(time <= amountOfTime)
        {
            _playerCharacterController.Move(directionPlayerShouldMove * Time.deltaTime);

            time += Time.deltaTime;

            yield return null;
        }
    }
}
