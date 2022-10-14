using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerInputsManager PlayerInputsManager { get; private set; }
    
    public PlayerCharacterControllerManager PlayerCharacterControllerManager { get; private set;}

    private void Awake()
    {
        PlayerInputsManager = GetComponentInChildren<PlayerInputsManager>();
        PlayerCharacterControllerManager = GetComponent<PlayerCharacterControllerManager>();
    }
}
