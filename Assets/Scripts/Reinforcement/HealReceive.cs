using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealReceive : ReceiveReinforcementHandler
{
    [SerializeField]
    private int _healValue;
    protected override void ApplyReinforcement()
    {
        Health playerHealth = _player.GetComponent<Health>();
        playerHealth.Heal(_healValue);
        Destroy(gameObject, 1f);
    }
}
