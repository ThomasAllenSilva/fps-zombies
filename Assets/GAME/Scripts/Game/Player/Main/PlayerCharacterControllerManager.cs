using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerCharacterControllerManager : MonoBehaviour
{
    [SerializeField] private LayerMask _playerStepsLayerMask;

    [Range(1f, 2f)] [SerializeField] private float _playerHeight = 1.22f;

    [Range(0.2f, 0.8f)] [SerializeField] private float _stepOffSet;

    private PlayerKnockBackController _playerKnockBackController;

    private Rigidbody _playerRigidbody;

    private Vector3 _playerDesiredPosition;

    private const float climbStepSpeed = 4f;

    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody>();

        _playerKnockBackController = GetComponent<PlayerController>().PlayerKnockBackController;
    }

    private void FixedUpdate()
    {
        MovePlayer();

        StepClimb();
    }

    private void MovePlayer()
    {
        if (!_playerKnockBackController.IsKnockingBacking)
        {
            _playerRigidbody.velocity = _playerDesiredPosition * Time.fixedDeltaTime;
        }
    }

    private void StepClimb()
    {
        if (Physics.SphereCast(transform.position, _stepOffSet, Vector3.down, out RaycastHit hit, 5f , _playerStepsLayerMask))
        {
            _playerDesiredPosition.y = hit.point.y + _playerHeight;
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, _playerDesiredPosition.y, transform.position.z), climbStepSpeed * Time.fixedDeltaTime);
    }

    public void AddForceToPlayer(Vector3 force)
    {

        _playerRigidbody.AddForce(force, ForceMode.Impulse);
        

    }

    public void ChangePlayerDirection(Vector3 directionPlayerShouldMove)
    {
        _playerDesiredPosition.x = directionPlayerShouldMove.x;

        _playerDesiredPosition.z = directionPlayerShouldMove.z;
    }
}
