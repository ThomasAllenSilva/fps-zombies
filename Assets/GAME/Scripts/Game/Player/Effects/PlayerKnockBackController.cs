using UnityEngine;

public class PlayerKnockBackController : MonoBehaviour, IKnockBack
{
    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    public void PlayKnockBackEffect(Vector3 knockBackDirection, float knockBackForce, float amountOfTime)
    {
        StartCoroutine(_playerController.PlayerCharacterControllerManager.MovePlayerTowardsDirectionWhileIsInTime(knockBackDirection * knockBackForce, amountOfTime));
    }
}
