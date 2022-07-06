using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShooting: Shooting
{
    private float _lastTime = 0;
    private float _interval = 1f;
    private void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        // if (Input.GetKeyDown(KeyCode.Y))
        if(ButtonToKeyConverter.s_buttonFire1Down && Time.time - _lastTime > _interval)
        {
            Shoot();
            _lastTime = Time.time;
        }
    }
    protected override void Shoot()
    {
        _animator.SetTrigger(ShootTrigger);
        base.Shoot();
    }
}
