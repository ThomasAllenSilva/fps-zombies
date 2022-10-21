using System.Collections;
using UnityEngine;

public class PlayerGunAimManager : MonoBehaviour
{
    [Range(1f, 3f)] [SerializeField] private float _weaponAimSpeed;

    private static Transform _weaponAimPosition;

    private PlayerGunController _playerGunController;

    private Vector3 _weaponDefaultPosition;

    private bool _playerIsHoldingAimWeaponButton;

    private void Awake()
    {
        _playerGunController = GetComponent<PlayerGunController>();

         if(_weaponAimPosition == null) _weaponAimPosition = transform.parent.GetChild(2).transform;
    }

    private void Start()
    {
        _playerGunController.GetPlayerController().PlayerInputsManager.OnPlayerIsPressingAimButton += AimWeapon;

        _playerGunController.GetPlayerController().PlayerInputsManager.OnPlayerStoppedPressingAimButtom += StopAimWeapon;

        _weaponDefaultPosition = transform.localPosition;
    }

    private void AimWeapon()
    {
        _playerIsHoldingAimWeaponButton = true;
        StartCoroutine(MoveWeaponToTheAimPosition());
    }

    private void StopAimWeapon()
    {
        _playerIsHoldingAimWeaponButton = false;
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
}
