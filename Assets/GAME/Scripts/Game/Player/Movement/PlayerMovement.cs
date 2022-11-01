using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class PlayerMovement : MonoBehaviour
{
    [Range(200f, 250f)] [SerializeField] private float playerWalkingSpeed = 200f;

    [Range(350f, 450f)] [SerializeField] private float playerRunningSpeed = 350f;

    private PlayerController _playerController;

    public bool PlayerIsRunning { get; private set; }

    public bool PlayerIsWalking { get {return _playerController.PlayerInputsManager.PlayerMovementValue() != Vector2.zero && !PlayerIsRunning; } private set { PlayerIsWalking = value; } }

    public bool PlayerIsMovingInFowardDirecion { get; private set; }

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        _playerController.PlayerInputsManager.OnPlayerIsPressingRunButton += PlayerIsPressingRunningButton;

        _playerController.PlayerInputsManager.OnPlayerStoppedPressingRunButton += PlayerHasStoppedPressingRunningButton;
    }

    private void Update()
    {
        Vector3 directionPlayerShouldMove = _playerController.PlayerCamera.forward * _playerController.PlayerInputsManager.PlayerMovementValue().y + _playerController.PlayerCamera.right * _playerController.PlayerInputsManager.PlayerMovementValue().x;

        directionPlayerShouldMove.y = 0;

        PlayerIsMovingInFowardDirecion = Vector3.Dot(transform.forward, directionPlayerShouldMove) > 0.5f;

        if (CheckIfPlayerCanRun())
        {
            _playerController.PlayerCharacterControllerManager.ChangePlayerDirection(directionPlayerShouldMove.normalized * playerRunningSpeed);
            return;
        }

        _playerController.PlayerCharacterControllerManager.ChangePlayerDirection(directionPlayerShouldMove.normalized * playerWalkingSpeed);

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
