using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _guns;

    private int _currentGun;

    private float _lastTime = 0;
    private float _interval = 1f;

    private void Update()
    {
        /*
        for (int i = 0; i < _guns.Length; i++)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SwitchToGun(i);
                break;
            }
        }
        */
        if (ButtonToKeyConverter.s_buttonSwitchGunDown == true && Time.time - _lastTime > _interval)
        {
            SwitchToNextGun();
            _lastTime = Time.time;
        }
    }

    public void SwitchToGun(int gunIndex)
    {
        for(int i = 0; i < _guns.Length; i++)
        {
            _guns[i].SetActive(i == gunIndex);
        }
    }

    public void SwitchToNextGun()
    {
        int selected = (_currentGun + 1) % _guns.Length;
        for (int i = 0; i < _guns.Length; i++)
        {
            _guns[i].SetActive(i == selected);
        }
        _currentGun = selected;
    }

    public void HideAllGuns()
    {
        for(int i = 0; i < _guns.Length; i++)
        {
            _guns[i].SetActive(false);
        }
    }
}
