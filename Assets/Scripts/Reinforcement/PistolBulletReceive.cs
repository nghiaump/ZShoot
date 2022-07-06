using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBulletReceive : ReceiveReinforcementHandler
{
    [SerializeField]
    private int _bulletNumber;
    protected override void ApplyReinforcement()
    {
        GunAmmo[] gunAmmos = _player.GetComponentsInChildren<GunAmmo>();
        for (int i = 0; i < gunAmmos.Length; i++)
        {
            if (gunAmmos[i].gameObject.GetComponent<PistolShooting>() != null)
            {
                gunAmmos[i].ReceiveReinforcement(_bulletNumber);
                break;
            }
        }
        Destroy(gameObject, 1f);
    }
}
