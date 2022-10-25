using System.Threading.Tasks;
using UnityEngine;

public class PlayerKnockBackController : MonoBehaviour, IKnockBack
{
    private PlayerController _playerController;

    public bool IsKnockingBacking { get; private set; }

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    public async void PlayKnockBackEffect(Vector3 knockBackDirection, float knockBackForce)
    {
        IsKnockingBacking = true;

        _playerController.PlayerCharacterControllerManager.AddForceToPlayer(knockBackDirection * knockBackForce);

        await Task.Delay(500);

        IsKnockingBacking = false;
    }
}
