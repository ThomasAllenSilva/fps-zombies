using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class PlayerMovement : MonoBehaviour
{
    [Range(3f, 8f)] [SerializeField] private float playerWalkingSpeed = 2f;

    [Range(5f, 12f)] [SerializeField] private float playerRunningSpeed = 4f;

    private PlayerController _playerController;

    private Transform _cameraTransform;

    public bool PlayerIsRunning { get; private set; }

    public bool PlayerIsWalking { get {return _playerController.PlayerInputsManager.PlayerMovementValue() != Vector2.zero && !PlayerIsRunning; } private set { PlayerIsWalking = value; } }

    public bool PlayerIsMovingInFowardDirecion { get; private set; }

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
   
        _cameraTransform = Camera.main.transform;
    }

    private void Start()
    {
        _playerController.PlayerInputsManager.OnPlayerIsPressingRunButton += PlayerIsPressingRunningButton;

        _playerController.PlayerInputsManager.OnPlayerStoppedPressingRunButton += PlayerHasStoppedPressingRunningButton;
    }

    private void Update()
    {
        Vector3 directionPlayerShouldMove = _cameraTransform.forward * _playerController.PlayerInputsManager.PlayerMovementValue().y + _cameraTransform.right * _playerController.PlayerInputsManager.PlayerMovementValue().x;

        directionPlayerShouldMove.y = 0;

        PlayerIsMovingInFowardDirecion = Vector3.Dot(transform.forward, directionPlayerShouldMove) > 0.5f;

        if (CheckIfPlayerCanRun())
        {
            _playerController.PlayerCharacterControllerManager.MovePlayerToDirection(directionPlayerShouldMove.normalized * playerRunningSpeed);
        }

        else
        {
            _playerController.PlayerCharacterControllerManager.MovePlayerToDirection(directionPlayerShouldMove.normalized * playerWalkingSpeed);
        }

        bool CheckIfPlayerCanRun()
        {
            return PlayerIsRunning && PlayerIsMovingInFowardDirecion && !PlayerGlobalGunManager.PlayerIsAiming && !PlayerGlobalGunManager.PlayerIsShooting && !PlayerGlobalGunManager.PlayerIsReloading;
        }
    }

    private void PlayerIsPressingRunningButton()
    {
        PlayerIsRunning = true;
    }

    private void PlayerHasStoppedPressingRunningButton()
    {
        PlayerIsRunning = false;
    }
}
