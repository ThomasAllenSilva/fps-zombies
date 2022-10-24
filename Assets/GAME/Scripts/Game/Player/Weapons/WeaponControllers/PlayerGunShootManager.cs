using UnityEngine;

[RequireComponent(typeof(PlayerGunController))]

public class PlayerGunShootManager : MonoBehaviour
{

    private PlayerGunController _playerGunController;

    private PlayerInputsManager _playerInputsManager;

    [SerializeField] private int _bulletDamage;

    [SerializeField] private int _gunMagazineSize;

    [SerializeField] private int _bulletsPerShoot;

    [SerializeField] private float _shootDelay;

    [SerializeField] private float _bulletSpreadRange;

    [SerializeField] private float maxDistanceTheBulletCanHit;

    [SerializeField] private LayerMask _bulletLayerMask;

    [SerializeField] private Transform bulletSpawmPosition;

    private Vector3 _randomBulletSpreadRangeValue = new Vector3(0f, 0f, 0f);

    private readonly RaycastHit[] rayHit = new RaycastHit[4];

    private const string EnemyTag = "Enemy";

    private int _bulletsLeft;

    private float _gunReloadTime;

    private float _defaultBulletSpreadRangeValue;

    private bool _playerIsReadyToShoot = true;

    public bool PlayerIsPressingShootButton { get; private set; }

    public bool PlayerIsReloading { get; private set; }

    private void Awake()
    {
        _playerGunController = GetComponent<PlayerGunController>();

        _defaultBulletSpreadRangeValue = _bulletSpreadRange;

        _playerInputsManager = _playerGunController.GetPlayerController().PlayerInputsManager;
    }
    
    private void Start()
    {
        _playerInputsManager.OnPlayerIsPressingShootButton += PlayerIsHoldingShootButton;

        _playerInputsManager.OnPlayerStoppedPressingShootButton += PlayerHasStoppedHoldingShootButton;

        _playerInputsManager.OnPlayerPressedReloadButton += ReloadGun;

        _playerInputsManager.OnPlayerIsPressingAimButton += ChangeBulletSpreadValueToMorePrecise;

        _playerInputsManager.OnPlayerStoppedPressingAimButtom += ChangeBulletSpreadRangeToDefaultValue;

        _bulletsLeft = _gunMagazineSize;
        
        _gunReloadTime = _playerGunController.PlayerGunAnimationManager.GetGunReloadAnimationTime();
    }

    private void Update()
    {
        if (CheckIfPlayerCanShoot() && PlayerIsPressingShootButton)
        {
            Shoot();
        }
    }

    private bool CheckIfPlayerCanShoot()
    {
        return _playerIsReadyToShoot && !PlayerIsReloading && _bulletsLeft >= _bulletsPerShoot;
    }

    private void Shoot()
    {
        _playerIsReadyToShoot = false;

        _bulletsLeft -= _bulletsPerShoot;

        Vector3 directionBulletRaycastShouldGo = bulletSpawmPosition.forward + GetRandomBulletSpreadValue();

        int amountOfObjectsHittedByShootRayCast = Physics.RaycastNonAlloc(transform.position, directionBulletRaycastShouldGo, rayHit, maxDistanceTheBulletCanHit, _bulletLayerMask);

        if (amountOfObjectsHittedByShootRayCast > 0)
        {
            for (int i = 0; i < amountOfObjectsHittedByShootRayCast; i++)
            {
                Collider objectHitted = rayHit[i].collider;

                if(objectHitted == null)
                {
                    continue;
                }

                if (objectHitted.gameObject.CompareTag(EnemyTag))
                {
                    Damageable damageable = rayHit[i].collider.gameObject.GetComponent<Damageable>();

                    damageable.TakeDamage(_bulletDamage);

                    break;
                }         
            }
        }

        if (_bulletsLeft >= _bulletsPerShoot)
        {
            Invoke(nameof(PlayerIsReadyToShootAgain), _shootDelay);

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

    private void PlayerIsReadyToShootAgain()
    {
        _playerIsReadyToShoot = true;
    }

    private void PlayerIsHoldingShootButton()
    {
        PlayerIsPressingShootButton = true;

        PlayerGlobalGunManager.SetPlayerIsHoldingShootButtonToTrue();
    }

    private void PlayerHasStoppedHoldingShootButton()
    {
        PlayerIsPressingShootButton = false;

        PlayerGlobalGunManager.SetPlayerIsHoldingShootButtonToFalse();
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

        PlayerIsReadyToShootAgain();
    }
}
