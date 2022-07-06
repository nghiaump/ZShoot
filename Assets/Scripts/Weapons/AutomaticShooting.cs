using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticShooting : Shooting
{
    private readonly int FireStateHash = Animator.StringToHash("AlternateSingleFire");

    [SerializeField]
    private float _rpm;

    private bool _isFiring;
    private float _lastShotTime;

    private void Update()
    {
        //_isFiring = Input.GetButton("Fire1");
        //_isFiring = Input.GetKey(KeyCode.Y);
        _isFiring = ButtonToKeyConverter.s_buttonFire1;

        if (_isFiring)
        {
            UpdateFiring();
        }
    }


    private void UpdateFiring()
    {
        float interval = 60f / _rpm;
        if(Time.time - _lastShotTime >= interval)
        {
            Shoot();
            _lastShotTime = Time.time;
        }

    }

    protected override void Shoot()
    {
        _animator.Play(FireStateHash, layer: 0, normalizedTime: 0);
        base.Shoot();
    }
}
