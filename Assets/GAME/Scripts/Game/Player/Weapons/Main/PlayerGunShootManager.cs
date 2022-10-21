using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerGunController))]

public class PlayerGunShootManager : MonoBehaviour
{
    private PlayerGunController _playerGunController;

    [SerializeField] private int _bulletDamage;

    [SerializeField] private int _gunMagazineSize;

    [SerializeField] private int _bulletsPerShoot;

    [SerializeField] private float _shootDelay;

    [SerializeField] private float _bulletSpreadRange;

    [SerializeField] private float maxDistanceTheBulletCanHit;

    [SerializeField] private LayerMask _bulletLayerMask;

    private float _gunReloadTime;

    private bool _playerCanShoot = true;

    private int _bulletsLeft;

    private Vector3 _randomBulletSpreadRangeValue = new Vector3(0f, 0f, 0f);

    private readonly RaycastHit[] rayHit = new RaycastHit[1];

    private float _defaultBulletSpreadRangeValue;

    public bool PlayerIsShooting { get; private set; }

    public bool PlayerIsReloading { get; private set; }

    [SerializeField] private Transform _weaponAimPosition;
    private Vector3 _weaponDefaultPosition = new Vector3(0f, .65f, -.07f);
    [SerializeField] private float _weaponAimSpeed;
    private bool _playerIsHoldingAimButton;

    private void Awake()
    {
        _playerGunController = GetComponent<PlayerGunController>();

        _defaultBulletSpreadRangeValue = _bulletSpreadRange;

        
    }
    
    private void Start()
    {
        _playerGunController.GetPlayerController().PlayerInputsManager.OnIsPressingShootButton += PlayerIsPressingShootButton;

        _playerGunController.GetPlayerController().PlayerInputsManager.OnStoppedPressingShootButton += PlayerHasStoppedShooting;

        _playerGunController.GetPlayerController().PlayerInputsManager.OnPressedReloadButton += ReloadGun;

        _playerGunController.GetPlayerController().PlayerInputsManager.OnPlayerIsPressingAimButton += AimWeapon;

        _playerGunController.GetPlayerController().PlayerInputsManager.OnPlayerStoppedPressingAimButtom += StopAimWeapon;

        _bulletsLeft = _gunMagazineSize;
        
        _gunReloadTime = _playerGunController.PlayerGunAnimationManager.GetGunReloadAnimationTime();
    }

    private void StopAimWeapon()
    {
        _playerIsHoldingAimButton = false;
        StartCoroutine(MoveWeaponToTheDefaultPosition());
   
        _bulletSpreadRange = _defaultBulletSpreadRangeValue;
    }

    private IEnumerator MoveWeaponToTheDefaultPosition()
    {
        while (transform.localPosition != _weaponDefaultPosition && !_playerIsHoldingAimButton)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, _weaponDefaultPosition, _weaponAimSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void AimWeapon()
    {
        _playerIsHoldingAimButton = true;
        StartCoroutine(MoveWeaponToTheAimPosition());
        
        _bulletSpreadRange *= 0.5f;
    }

    private void Update()
    {
        if (CheckIfPlayerCanShoot() && PlayerIsShooting)
        {
            Shoot();
        }
    }

    private bool CheckIfPlayerCanShoot()
    {
        return _playerCanShoot && !PlayerIsReloading && _bulletsLeft > 0;
    }

    private void Shoot()
    {
        _playerCanShoot = false;

        _bulletsLeft -= _bulletsPerShoot;

        Vector3 directionBulletRaycastShouldGo = transform.forward + GetRandomBulletSpreadValue();

        if (Physics.RaycastNonAlloc(transform.position, directionBulletRaycastShouldGo, rayHit, maxDistanceTheBulletCanHit, _bulletLayerMask) > 0)
        {
            //TODO Handle ray collision
        }

        if(_bulletsLeft > 0) Invoke(nameof(AllowPlayerShootAgain), _shootDelay);

        else ReloadGun();   
    }

    private Vector3 GetRandomBulletSpreadValue()
    {
        _randomBulletSpreadRangeValue.x = Random.Range(-_bulletSpreadRange, _bulletSpreadRange);
        _randomBulletSpreadRangeValue.y = Random.Range(-_bulletSpreadRange, _bulletSpreadRange);

        return _randomBulletSpreadRangeValue;
    }

    private void AllowPlayerShootAgain()
    {
        _playerCanShoot = true;
    }

    private void PlayerHasStoppedShooting()
    {
        PlayerIsShooting = false;
    }

    private void PlayerIsPressingShootButton()
    {
        PlayerIsShooting = true;
    }

    private void ReloadGun()
    {
        if (!PlayerIsReloading && _bulletsLeft < _gunMagazineSize)
        {
            PlayerIsReloading = true;
            Invoke(nameof(ReloadFinished), _gunReloadTime);
        }
    }

    private void ReloadFinished()
    {
        _bulletsLeft = _gunMagazineSize;

        PlayerIsReloading = false;

        AllowPlayerShootAgain();
    }

    private IEnumerator MoveWeaponToTheAimPosition()
    {
        while (transform.localPosition != _weaponAimPosition.localPosition && _playerIsHoldingAimButton)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, _weaponAimPosition.localPosition, _weaponAimSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
