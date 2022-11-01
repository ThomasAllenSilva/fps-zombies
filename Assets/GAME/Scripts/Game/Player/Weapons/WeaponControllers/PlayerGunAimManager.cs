using System.Collections;
using UnityEngine;

public class PlayerGunAimManager : MonoBehaviour
{
    [Range(1f, 3f)] [SerializeField] private float _weaponAimSpeed;

    private static Transform _weaponAimPosition;

    private static readonly int _weaponAimPositionChildIndex = 3;

    private PlayerGunController _playerGunController;

    private Vector3 _weaponDefaultPosition;

    private bool _playerIsHoldingAimWeaponButton;

    private void Awake() => _playerGunController = GetComponentInChildren<PlayerGunController>();

    private void Start()
    {
        _weaponAimPosition = transform.parent.GetChild(_weaponAimPositionChildIndex).transform;

        _weaponDefaultPosition = transform.localPosition;
    }

    private void AimWeapon()
    {
        _playerIsHoldingAimWeaponButton = true;

        PlayerGlobalGunManager.SetPlayerIsAimingToTrue();

        StartCoroutine(MoveWeaponToTheAimPosition());
    }

    private void StopAimWeapon()
    {
        _playerIsHoldingAimWeaponButton = false;

        PlayerGlobalGunManager.SetPlayerIsAimingToFalse();

        StartCoroutine(MoveWeaponToTheDefaultPosition());
    }

    private IEnumerator MoveWeaponToTheAimPosition()
    {
        while (transform.localPosition != _weaponAimPosition.localPosition && _playerIsHoldingAimWeaponButton)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, _weaponAimPosition.localPosition, _weaponAimSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator MoveWeaponToTheDefaultPosition()
    {
        while (transform.localPosition != _weaponDefaultPosition && !_playerIsHoldingAimWeaponButton)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, _weaponDefaultPosition, _weaponAimSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnEnable()
    {
        _playerGunController.GetPlayerController().PlayerInputsManager.OnPlayerIsPressingAimButton += AimWeapon;

        _playerGunController.GetPlayerController().PlayerInputsManager.OnPlayerStoppedPressingAimButtom += StopAimWeapon;
    }

    private void OnDisable()
    {
        _playerGunController.GetPlayerController().PlayerInputsManager.OnPlayerIsPressingAimButton -= AimWeapon;

        _playerGunController.GetPlayerController().PlayerInputsManager.OnPlayerStoppedPressingAimButtom -= StopAimWeapon;
    }
}
