using UnityEngine;

[RequireComponent(typeof(PlayerGunController))]

public class PlayerGunShootManager : MonoBehaviour
{
    private PlayerGunController _playerGunController;

    [SerializeField] private int _bulletDamage;

    [SerializeField] private int _gunMagazineSize;

    [SerializeField] private int _bulletsPerShoot;

    [SerializeField] private float _shootDelay;

    [SerializeField] private float _bulletSpreadMaxRange;

    [SerializeField] private float maxDistanceTheBulletCanHit;

    [SerializeField] private LayerMask _bulletLayerMask;

    private float _gunReloadTime;

    private bool _playerCanShoot = true;

    private int _bulletsLeft;

    private Vector3 _randomBulletSpreadValue = new Vector3(0f, 0f, 0f);

    private readonly RaycastHit[] rayHit = new RaycastHit[1];

    public bool PlayerIsShooting { get; private set; }

    public bool PlayerIsReloading { get; private set; }

    private void Awake()
    {
        _playerGunController = GetComponent<PlayerGunController>();
    }
    
    private void Start()
    {
        _playerGunController.GetPlayerController().PlayerInputsManager.OnIsPressingShootButton += PlayerIsPressingShootButton;

        _playerGunController.GetPlayerController().PlayerInputsManager.OnStoppedPressingShootButton += PlayerHasStoppedShooting;

        _playerGunController.GetPlayerController().PlayerInputsManager.OnPressedReloadButton += ReloadGun;

        _bulletsLeft = _gunMagazineSize;

        _gunReloadTime = _playerGunController.PlayerGunAnimationManager.GetGunReloadAnimationTime();
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
        _randomBulletSpreadValue.x = Random.Range(-_bulletSpreadMaxRange, _bulletSpreadMaxRange);
        _randomBulletSpreadValue.y = Random.Range(-_bulletSpreadMaxRange, _bulletSpreadMaxRange);

        return _randomBulletSpreadValue;
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
}
