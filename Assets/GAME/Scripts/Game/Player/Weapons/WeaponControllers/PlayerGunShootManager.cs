using UnityEngine;
using System;

[RequireComponent(typeof(PlayerGunController))]

public class PlayerGunShootManager : MonoBehaviour
{

    private PlayerGunController _playerGunController;

    private PlayerInputsManager _playerInputsManager;

    [SerializeField] private int _bulletDamage;

    [field: SerializeField] public int GunMagazineSize { get; private set; }

    [field: SerializeField] public int MaxBullets { get; private set; }

    [SerializeField] private int _bulletsPerShoot;

    [SerializeField] private float _shootDelay;

    [SerializeField] private float _bulletSpreadRange;

    [SerializeField] private float maxDistanceTheBulletCanHit;

    [SerializeField] private LayerMask _bulletLayerMask;

    [SerializeField] private Transform bulletSpawmPosition;

    private Vector3 _randomBulletSpreadRangeValue = new Vector3(0f, 0f, 0f);

    private readonly RaycastHit[] rayHit = new RaycastHit[4];

    private const string EnemyTag = "Enemy";

    public int BulletsLeft { get; private set; }

    private float _gunReloadTime;

    private float _defaultBulletSpreadRangeValue;

    private bool _playerIsReadyToShoot = true;

    public bool PlayerIsPressingShootButton { get; private set; }

    public bool PlayerIsShooting { get; private set; }

    public bool PlayerIsReloading { get; private set; }

    public static event Action OnPlayerStartedReloading;

    public static event Action OnPlayerFinishedReloading;

    public static event Action OnPlayerIsShooting;

    private void Awake()
    {
        _playerGunController = GetComponent<PlayerGunController>();

        _playerInputsManager = _playerGunController.GetPlayerController().PlayerInputsManager;

        _defaultBulletSpreadRangeValue = _bulletSpreadRange;

        BulletsLeft = GunMagazineSize;

        _gunReloadTime = _playerGunController.PlayerGunAnimationManager.GetGunReloadAnimationTime();
    }
    
    private void Start()
    {
        _playerInputsManager.OnPlayerIsPressingShootButton += PlayerIsHoldingShootButton;

        _playerInputsManager.OnPlayerStoppedPressingShootButton += PlayerHasStoppedHoldingShootButton;

        _playerInputsManager.OnPlayerPressedReloadButton += ReloadGun;

        _playerInputsManager.OnPlayerIsPressingAimButton += ChangeBulletSpreadValueToMorePrecise;

        _playerInputsManager.OnPlayerStoppedPressingAimButtom += ChangeBulletSpreadRangeToDefaultValue;

    }

    private void Update()
    {
       
        if (CheckIfPlayerCanShoot() && PlayerIsPressingShootButton)
        {
            Shoot();      

            OnPlayerIsShooting?.Invoke();

     


            return;
        }
    }

   
    private bool CheckIfPlayerCanShoot()
    {
        return _playerIsReadyToShoot && !PlayerIsReloading && BulletsLeft >= _bulletsPerShoot && !_playerGunController.PlayerIsHidingWeapon;
    }

    private void Shoot()
    {
        PlayerIsShooting = true;


        PlayerGlobalGunManager.SetPlayerIsShootingButtonToTrue();

        _playerIsReadyToShoot = false;

        BulletsLeft -= _bulletsPerShoot;

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
                    Damageable damageable = objectHitted.gameObject.GetComponent<Damageable>();

                    damageable.TakeDamage(_bulletDamage);

                    break;
                }         
            }
        }

        if (BulletsLeft >= _bulletsPerShoot)
        {

            Invoke(nameof(PlayerIsReadyToShootAgain), _shootDelay);


            return;
        }


        Invoke(nameof(ReloadGun), _shootDelay);
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
        _randomBulletSpreadRangeValue.x = UnityEngine.Random.Range(-_bulletSpreadRange, _bulletSpreadRange);

        _randomBulletSpreadRangeValue.y = UnityEngine.Random.Range(-_bulletSpreadRange, _bulletSpreadRange);

        return _randomBulletSpreadRangeValue;
    }

    private void PlayerIsReadyToShootAgain()
    {
        _playerIsReadyToShoot = true;
    }

    private void PlayerIsHoldingShootButton()
    {
        PlayerIsPressingShootButton = true;

    }

    private void PlayerHasStoppedHoldingShootButton()
    {
        PlayerIsPressingShootButton = false;

        PlayerIsShooting = false;

        PlayerGlobalGunManager.SetPlayerIsShootingButtonToFalse();
    }

    private void ReloadGun()
    {
        if (!PlayerIsReloading && BulletsLeft < GunMagazineSize && MaxBullets > 0 && !_playerGunController.PlayerIsHidingWeapon)
        {
            PlayerIsShooting = false;

            PlayerGlobalGunManager.SetPlayerIsShootingButtonToFalse();

            PlayerIsReloading = true;

            PlayerGlobalGunManager.SetPlayerIsReloadingToTrue();

            OnPlayerStartedReloading?.Invoke();

            Invoke(nameof(ReloadFinished), _gunReloadTime);
        }
    }

    private void ReloadFinished()
    {
        PlayerIsReloading = false;

        PlayerGlobalGunManager.SetPlayerIsReloadingToFalse();

        if((MaxBullets >= GunMagazineSize))
        {
            MaxBullets -= GunMagazineSize - BulletsLeft;
            BulletsLeft = GunMagazineSize;
        }

        else
        {
            BulletsLeft = MaxBullets;
            MaxBullets = 0;
        }

        OnPlayerFinishedReloading?.Invoke();

        PlayerIsReadyToShootAgain();
    }

    private void OnEnable()
    {
        PlayerGlobalGunManager.ChangeCurrentActiveGun(this);
    }
}
