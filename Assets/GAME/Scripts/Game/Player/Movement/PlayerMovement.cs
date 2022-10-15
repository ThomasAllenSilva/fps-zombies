using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class PlayerMovement : MonoBehaviour
{
    [Range(1f, 3f)] [SerializeField] private float playerWalkingSpeed = 2f;
    [Range(3f, 5f)] [SerializeField] private float playerRunningSpeed = 4f;

    private PlayerController _playerController;

    private Transform _cameraTransform;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
   
        _cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        Vector3 directionPlayerShouldMove = _cameraTransform.forward * _playerController.PlayerInputsManager.PlayerMovementValue().y + _cameraTransform.right * _playerController.PlayerInputsManager.PlayerMovementValue().x;
        directionPlayerShouldMove.y = 0;

        _playerController.PlayerCharacterControllerManager.MovePlayerToDirection(directionPlayerShouldMove.normalized * playerWalkingSpeed); 
    }
}
