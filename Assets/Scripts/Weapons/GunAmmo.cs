using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAmmo : MonoBehaviour
{
    private readonly int ReloadTrigger = Animator.StringToHash("Reload");

    [field: SerializeField]
    public int RemainingAmmo { get; private set; }

    public System.Action OnAmmoChanged;

    [HideInInspector]
    [SerializeField]
    private Animator _animator;

    [HideInInspector]
    [SerializeField]
    private Shooting _shooting;

    [SerializeField]
    private AudioSource[] _reloadSounds;



    [SerializeField]
    private int _magazineSize;

    private int _loadedAmmo;

    public int LoadedAmmo
    {
        get => _loadedAmmo;
        set
        {
            _loadedAmmo = value;
            LockShooting();
            OnAmmoChanged?.Invoke();
        }
    }

    private bool _isReloading;
    private float _lastTime = 0;
    private float _interval = 2f;


    private void OnValidate()
    {
        // Lay tu dong
        _animator = GetComponent<Animator>();
        _shooting = GetComponent<Shooting>();
        
    }

    private void OnEnable()
    {
        _isReloading = false;
        UnlockShooting();
    }

    private void Start()
    {
        LoadedAmmo = _magazineSize;
        _shooting.OnShoot.AddListener(OnShoot);
    }

    private void OnShoot() => LoadedAmmo--;

    private void Update()
    {
        if (_isReloading) return;

        // if (Input.GetKeyDown(KeyCode.R) || LoadedAmmo == 0)
        if (ButtonToKeyConverter.s_buttonReloadDown || LoadedAmmo == 0)
        {
            if(Time.time - _lastTime > _interval)
            {
                Reload();
                _lastTime = Time.time;
            }
            
        }

        
    }

    private void Reload()
    {
        if(RemainingAmmo > 0 && LoadedAmmo != _magazineSize)
        {
            _animator.SetTrigger(ReloadTrigger);
            _isReloading = true;

            // Lock shooting when reload
            _shooting.Lock();

        }
    }

    public void AddAmmo()
    {
        int requiredAmmo = _magazineSize - LoadedAmmo;
        int addedAmmo = Mathf.Min(requiredAmmo, RemainingAmmo);

        RemainingAmmo -= addedAmmo;
        LoadedAmmo += addedAmmo;
    }

    public void ReceiveReinforcement(int receivedAmmo)
    {
        Debug.Log("add ammo");
        RemainingAmmo += receivedAmmo;
    }

    public void PlayReloadPart1Sound() => _reloadSounds[0].Play();
    public void PlayReloadPart2Sound() => _reloadSounds[1].Play();
    public void PlayReloadPart3Sound() => _reloadSounds[2].Play();
    public void PlayReloadPart4Sound() => _reloadSounds[3].Play();
    public void PlayReloadPart5Sound() => _reloadSounds[4].Play();

    public void ReloadToIdle()
    {
        _isReloading = false;
        _shooting.Unlock();
    }

    private void UnlockShooting()
    {
        if(_loadedAmmo > 0)
        {
            _shooting.Unlock();
        }
    }

    private void LockShooting()
    {
        if (LoadedAmmo <= 0)
        {
            _shooting.Lock();
        }
    }
}
