using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    private static PlayerController _playerController;

    public PlayerGunAnimationManager PlayerGunAnimationManager { get; private set; }

    public PlayerGunShootManager PlayerGunShootManager { get; private set; }

    private void Awake()
    {
        PlayerGunAnimationManager = GetComponent<PlayerGunAnimationManager>();

        PlayerGunShootManager = GetComponent<PlayerGunShootManager>();

        _playerController = GetComponentInParent<PlayerController>();
    }

    public PlayerController GetPlayerController()
    {
        return _playerController;
    }   
}
