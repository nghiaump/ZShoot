using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieManager : MonoBehaviour
{
    [HideInInspector]
    [SerializeField]
    private Transform[] _spawnPoints;

    [SerializeField]
    private GameObject _zombiePrefab;

    [SerializeField]
    private int _maxZombieNumber;

    public static int AliveZombies = 0;
    public static int KilledZombie = 0;

    UnityEvent OnMissionCompleted;
    public static System.Action OnZombieKilled;

    private void OnValidate()
    {
        GameObject zombieSpawners = GameObject.FindGameObjectWithTag("ZombieSpawners");
        _spawnPoints = zombieSpawners.GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        if(AliveZombies < _maxZombieNumber)
        {
            Invoke("SpawnNewZombie", Random.Range(0f, 5f));
            IncreaseZombieNumber();
        }
    }
    private void SpawnNewZombie()
    {
        Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        Instantiate(_zombiePrefab, spawnPoint.position, Quaternion.identity);
    }

    private void IncreaseZombieNumber()
    {
        AliveZombies++;
    }

    public static void DecreaseZombieNumber()
    {
        if(AliveZombies > 0)
        {
            AliveZombies--;
            KilledZombie++;
            OnZombieKilled.Invoke();
        }
    }
}
