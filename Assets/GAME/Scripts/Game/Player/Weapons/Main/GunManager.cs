using System;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] private int _bulletDamage;
    [SerializeField] private int _bulletsLeft;
    [SerializeField] private int _bulletsShot;
    [SerializeField] private int _magazineSize;
    [SerializeField] private int _bulletsPerTap;

    [SerializeField] private float _shootDelay;
    [SerializeField] private float _bulletSpread;
    [SerializeField] private float _bulletRange;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _timeBetweenShoots;

    [SerializeField] private bool allowButtonHold;
    private bool _shooting;
    private bool _readyToShoot;
    private bool _reloading;

    private Camera playerCamera;
    [SerializeField] private Transform shootSpawnPoint;
    [SerializeField] private RaycastHit rayHit;
    [SerializeField] private LayerMask bulletMask;

    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = transform.parent.parent.GetComponent<PlayerController>();
    }

    private void Start()
    {
        if (allowButtonHold) _playerController.PlayerInputsManager.OnIsPressingShootButton += IsShooting;

        _playerController.PlayerInputsManager.OnStopPressingShootButton += StopedShooting;

    }

    private void StopedShooting()
    {
        _shooting = false;
    }

    private void IsShooting()
    {
        _shooting = true;
    }
}
