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

    [SerializeField] private Transform bulletSpawmPosition;

    private float _gunReloadTime;

    private bool _playerCanShoot = true;

    private int _bulletsLeft;

    private Vector3 _randomBulletSpreadRangeValue = new Vector3(0f, 0f, 0f);

    private readonly RaycastHit[] rayHit = new RaycastHit[4];

    private float _defaultBulletSpreadRangeValue;

    private const string EnemyTag = "Enemy";

    public bool PlayerIsShooting { get; private set; }

    public bool PlayerIsReloading { get; private set; }

    private void Awake()
    {
        _playerGunController = GetComponent<PlayerGunController>();

        _defaultBulletSpreadRangeValue = _bulletSpreadRange;
    }
    
    private void Start()
    {
        _playerGunController.GetPlayerController().PlayerInputsManager.OnPlayerIsPressingShootButton += PlayerIsPressingShootButton;

        _playerGunController.GetPlayerController().PlayerInputsManager.OnPlayerStoppedPressingShootButton += PlayerHasStoppedShooting;

        _playerGunController.GetPlayerController().PlayerInputsManager.OnPlayerPressedReloadButton += ReloadGun;

        _playerGunController.GetPlayerController().PlayerInputsManager.OnPlayerIsPressingAimButton += ChangeBulletSpreadValueToMorePrecise;

        _playerGunController.GetPlayerController().PlayerInputsManager.OnPlayerStoppedPressingAimButtom += ChangeBulletSpreadRangeToDefaultValue;

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

        Vector3 directionBulletRaycastShouldGo = bulletSpawmPosition.forward + GetRandomBulletSpreadValue();

        if (Physics.RaycastNonAlloc(transform.position, directionBulletRaycastShouldGo, rayHit, maxDistanceTheBulletCanHit, _bulletLayerMask) > 0)
        {
            for (int i = 0; i < rayHit.Length; i++)
            {
                if (rayHit[i].collider != null && rayHit[i].collider.gameObject.CompareTag(EnemyTag))
                {
                    Damageable damageable = rayHit[i].collider.gameObject.GetComponent<Damageable>();

                    damageable.TakeDamage(_bulletDamage);
                    break;
                }
            }
        }

        if (_bulletsLeft > 0)
        {
            Invoke(nameof(AllowPlayerShootAgain), _shootDelay);
            return;
        }

        ReloadGun();
    }

    private void ChangeBulletSpreadRangeToDefaultValue()
    {
        _bulletSpreadRange = _defaultBulletSpreadRangeValue;
    }

    private void ChangeBulletSpreadValueToMorePrecise()
    {
        _bulletSpreadRange *= 0.5f;
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
        PlayerGlobalGunManager.SetPlayerIsShootingToFalse();
    }

    private void PlayerIsPressingShootButton()
    {
        PlayerIsShooting = true;

        PlayerGlobalGunManager.SetPlayerIsShootingToTrue();
    }

    private void ReloadGun()
    {
        if (!PlayerIsReloading && _bulletsLeft < _gunMagazineSize)
        {
            PlayerIsReloading = true;

            PlayerGlobalGunManager.SetPlayerIsReloadingToTrue();

            Invoke(nameof(ReloadFinished), _gunReloadTime);
        }
    }

    private void ReloadFinished()
    {
        _bulletsLeft = _gunMagazineSize;

        PlayerIsReloading = false;

        PlayerGlobalGunManager.SetPlayerIsReloadingToFalse();

        AllowPlayerShootAgain();
    }
}
