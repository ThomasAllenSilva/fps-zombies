using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerInputsManager PlayerInputsManager { get; private set; }
    
    public PlayerCharacterControllerManager PlayerCharacterControllerManager { get; private set;}

    public PlayerMovement PlayerMovementManager { get; private set; }

    public PlayerKnockBackController PlayerKnockBackController { get; private set; }

    public Transform PlayerCamera { get; private set; }

    private void Awake()
    {
        PlayerInputsManager = GetComponentInChildren<PlayerInputsManager>();

        PlayerCharacterControllerManager = GetComponent<PlayerCharacterControllerManager>();

        PlayerMovementManager = GetComponent<PlayerMovement>();

        PlayerKnockBackController = GetComponent<PlayerKnockBackController>();

        PlayerCamera = Camera.main.transform;
    }
}
