using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ZombieNavigator : MonoBehaviour
{
    private readonly int IsChasingHash = Animator.StringToHash("IsChasing");

    public UnityEvent OnTargetReached;
    public UnityEvent OnStartChasing;

    
    [SerializeField]
    private NavMeshAgent _navAgent;
    [SerializeField]
    private float _stoppingDistance;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private float _timeToHideOnDead;

    private bool _isChasing;
    public bool IsChasing
    {
        get => _isChasing;
        private set
        {
            // Avoid unneccessary loop
            if (_isChasing == value) return;

            _isChasing = value;
            _navAgent.isStopped = !_isChasing;
            _animator.SetBool(IsChasingHash, _isChasing);

            if (IsChasing) OnStartChasing.Invoke();
            else OnTargetReached.Invoke();
            
        }
    }

    private Transform _playerTransform;

    private void OnValidate()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        float distance = Vector3.Distance(transform.position, _playerTransform.position);
        IsChasing = distance > _stoppingDistance;
        UpdateChasing();
    }

    private void UpdateChasing()
    {
        if (IsChasing)
        {
            _navAgent.SetDestination(_playerTransform.position);
        }
    }

    public void OnDead()
    {
        IsChasing = false;
        enabled = false;
        ZombieManager.DecreaseZombieNumber();
        Destroy(gameObject, _timeToHideOnDead);
    }
}
