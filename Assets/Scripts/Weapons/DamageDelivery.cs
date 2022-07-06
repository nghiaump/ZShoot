using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDelivery : MonoBehaviour
{
    [SerializeField]
    private Transform _aimingCamera;

    [SerializeField]
    private GameObject _hitEffectPrefab;

    [SerializeField]
    private int _damage;

    public void OnShoot()
    {
        PerformRaycasting();
    }

    private void PerformRaycasting()
    {
        Ray aimingRay = new Ray(_aimingCamera.position, _aimingCamera.forward);
        if (Physics.Raycast(aimingRay, out RaycastHit hitInfo))
        {
            UpdateTargetHealth(hitInfo);
            CreateHitEffect(hitInfo);
        }
    }

    private void UpdateTargetHealth(RaycastHit hitInfo)
    {
        Health health = hitInfo.collider.gameObject.GetComponentInParent<Health>();
        if (health != null)
        {
            health.TakeDamage(_damage);
        }
    }

    private void CreateHitEffect(RaycastHit hitInfo)
    {
        Quaternion holeRotation = Quaternion.LookRotation(hitInfo.normal);
        Instantiate(_hitEffectPrefab, hitInfo.point, holeRotation, hitInfo.collider.transform);
    }
}
