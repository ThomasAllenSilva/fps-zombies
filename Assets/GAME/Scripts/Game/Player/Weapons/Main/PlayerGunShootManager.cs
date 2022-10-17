using System;
using UnityEngine;

[RequireComponent(typeof(PlayerGunController))]

public class PlayerGunShootManager : MonoBehaviour
{
    private static PlayerController _playerController;

    private PlayerGunController _playerGunController;

    [SerializeField] private int _bulletDamage;

    [SerializeField] private int _gunMagazineSize;

    [SerializeField] private int _bulletsPerShoot;

    [SerializeField] private float _shootDelay;

    [SerializeField] private float _bulletSpreadMaxRange;

    [SerializeField] private float maxDistanceTheBulletCanHit;

    [SerializeField] private LayerMask _bulletLayerMask;

    private float _gunReloadTime;

    private bool _playerIsPressingShootButton;

    private bool _playerCanShoot = true;

    private bool _reloading;

    private int _bulletsLeft;

    private Vector3 _randomBulletSpreadValue = new Vector3(0f, 0f, 0f);

    private readonly RaycastHit[] rayHit = new RaycastHit[1];

    public event Action OnPlayerStartReloading;

    private void Awake()
    {
        _playerController = transform.parent.parent.GetComponent<PlayerController>();

        _playerGunController = GetComponent<PlayerGunController>();
    }
    
    private void Start()
    {
        _playerController.PlayerInputsManager.OnIsPressingShootButton += PlayerIsPressingShootButton;

        _playerController.PlayerInputsManager.OnStopPressingShootButton += PlayerHasStopedShooting;

        _playerController.PlayerInputsManager.OnPressedReloadButton += ReloadGun;

        _bulletsLeft = _gunMagazineSize;

        _gunReloadTime = _playerGunController.PlayerGunAnimationManager.GetGunReloadAnimationTime();
    }

    private void Update()
    {
        if (CheckIfPlayerCanShoot() && _playerIsPressingShootButton)
        {
            Shoot();
        }
    }

    private bool CheckIfPlayerCanShoot()
    {
        return _playerCanShoot && !_reloading && _bulletsLeft > 0;
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

        if(_bulletsLeft > 0)
        Invoke(nameof(AllowPlayerShootAgain), _shootDelay);

        else
        {
            ReloadGun();
        }
    }

    private Vector3 GetRandomBulletSpreadValue()
    {
        _randomBulletSpreadValue.x = UnityEngine.Random.Range(-_bulletSpreadMaxRange, _bulletSpreadMaxRange);
        _randomBulletSpreadValue.y = UnityEngine.Random.Range(-_bulletSpreadMaxRange, _bulletSpreadMaxRange);

        return _randomBulletSpreadValue;
    }

    private void AllowPlayerShootAgain()
    {
        _playerCanShoot = true;
    }

    private void PlayerHasStopedShooting()
    {
        _playerIsPressingShootButton = false;
    }

    private void PlayerIsPressingShootButton()
    {
        _playerIsPressingShootButton = true;
    }

    private void ReloadGun()
    {
        _reloading = true;
        OnPlayerStartReloading?.Invoke();
        Invoke(nameof(ReloadFinished), _gunReloadTime);
    }

    private void ReloadFinished()
    {
        _bulletsLeft = _gunMagazineSize;

        AllowPlayerShootAgain();

        _reloading = false;
    }
}
