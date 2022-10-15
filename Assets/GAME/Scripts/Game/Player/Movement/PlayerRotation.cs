using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [Range(0f, 50f)] [SerializeField] private float _playerRotationSpeed;

    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }
    private void LateUpdate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_playerController.PlayerCamera.eulerAngles), _playerRotationSpeed * Time.deltaTime);

    }
}
