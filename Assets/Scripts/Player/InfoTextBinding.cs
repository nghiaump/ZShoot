using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoTextBinding : MonoBehaviour
{
    [SerializeField]
    private Health _health;

    [SerializeField]
    private TMP_Text _killedZombiesText;

    [SerializeField]
    private TMP_Text _healthText;

    void Start()
    {
        _health.OnHPChanged += UpdateHP;
        ZombieManager.OnZombieKilled += UpdateKilledZombie;
        UpdateHP();
        UpdateKilledZombie();
    }

    private void UpdateHP() => _healthText.text = $"HP: {_health.HP}";

    private void UpdateKilledZombie() => _killedZombiesText.text = $"Target: {ZombieManager.KilledZombie}";
}