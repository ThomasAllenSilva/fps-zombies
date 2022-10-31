using UnityEngine;

public class PlayerGunAnimationEvents : MonoBehaviour
{
    public void DisableWeapon()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
