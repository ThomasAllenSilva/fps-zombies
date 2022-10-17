using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    public PlayerGunAnimationManager PlayerGunAnimationManager { get; private set; }

    public PlayerGunShootManager PlayerGunShootManager { get; private set; }

    public PlayerController PlayerController { get; private set; }

    private void Awake()
    {
        PlayerGunAnimationManager = GetComponent<PlayerGunAnimationManager>();
        PlayerGunShootManager = GetComponent<PlayerGunShootManager>();
        PlayerController = transform.parent.parent.GetComponent<PlayerController>();
    }
    
}
