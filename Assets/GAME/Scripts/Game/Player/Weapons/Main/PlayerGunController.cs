using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    private static PlayerController _playerController;

    private static PlayerGunChangeManager _playerGunChangeManager;

    public PlayerGunAnimationManager PlayerGunAnimationManager { get; private set; }

    public PlayerGunShootManager PlayerGunShootManager { get; private set; }

    private void Awake()
    {
        PlayerGunAnimationManager = GetComponent<PlayerGunAnimationManager>();

        PlayerGunShootManager = GetComponent<PlayerGunShootManager>();

        _playerController = GetComponentInParent<PlayerController>();

        _playerGunChangeManager = transform.parent.parent.GetComponent<PlayerGunChangeManager>();

     
    }

    private void Start()
    {
        _playerGunChangeManager.AddGunToCurrentGunsInSlot(this);
    }

    public PlayerController GetPlayerController()
    {
        return _playerController;
    }   

    public void DeactivateThisWeapon()
    {
        PlayerGunAnimationManager.PlayHideGunAnimation();
    }

    private void OnEnable()
    {


    }
}
