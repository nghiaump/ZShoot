using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{
    [SerializeField]
    private int _healthPoint;

    public int HP { get { return _healthPoint; } }

    public UnityEvent OnDead;

    public System.Action OnHPChanged;

    private bool IsDead => _healthPoint == 0;

    public void TakeDamage(int damage)
    {
        if (IsDead) return;
        _healthPoint -= damage;
        if(_healthPoint <= 0) _healthPoint = 0;

        if(gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            OnHPChanged.Invoke();
        }

        if (IsDead)
        {
            Die();
        }
    }

    // For Player only
    public void Heal(int healValue)
    {
        _healthPoint += healValue;
        OnHPChanged.Invoke();
    }

    private void Die()
    {
        OnDead.Invoke();
    }
}
