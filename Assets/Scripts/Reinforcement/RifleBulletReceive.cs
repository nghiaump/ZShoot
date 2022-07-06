using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleBulletReceive : ReceiveReinforcementHandler
{
    [SerializeField]
    private int _bulletNumber;
    protected override void ApplyReinforcement()
    {
        GunAmmo gunAmmo = GameObject.FindGameObjectWithTag("Rifle").GetComponent<GunAmmo>();
        gunAmmo?.ReceiveReinforcement(_bulletNumber);
        Destroy(gameObject, 1f);
    }
}
