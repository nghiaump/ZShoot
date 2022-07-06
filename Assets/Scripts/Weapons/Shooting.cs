using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    protected readonly int ShootTrigger = Animator.StringToHash("Shoot");

    public UnityEvent OnShoot;

    [SerializeField]
    protected Button _fireButton;

    [HideInInspector]
    [SerializeField]
    protected Animator _animator;

    [SerializeField]
    protected AudioSource _fireSound;

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
    }


    protected virtual void Shoot()
    {
        OnShoot?.Invoke();
    }

    public void PlayFireSound()
    {
        _fireSound.Play();
    }

    public void Lock() => enabled = false;
    public void Unlock() => enabled = true;
}
