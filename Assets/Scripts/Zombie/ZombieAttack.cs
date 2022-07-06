using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private int _damage;

    private GameObject _player;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void StartAttacking()
    {
        _animator.SetBool("IsAttacking", true);
        _animator.applyRootMotion = true;
    }

    public void StopAttacking()
    {
        _animator.SetBool("IsAttacking", false);
        _animator.applyRootMotion = false;
    }

    public void OnAttack1()
    {
        Health playerHealth = _player.GetComponent<Health>();
        playerHealth?.TakeDamage(_damage);        
    }

    public void OnAttack2()
    {
        Health playerHealth = _player.GetComponent<Health>();
        playerHealth?.TakeDamage(_damage * 2);

    }
}
