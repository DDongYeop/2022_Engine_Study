using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    private Enemy _enemyTarget;

    [SerializeField] private float _damage = 2;
    [SerializeField] private float _minDisToDealDamage = 0.1f;

    public TurretProjectile turretOwner { get; set; }

    private void Update()
    {
        if (_enemyTarget != null)
        {
            MoveProjectile();
            RotateProjectile();
        }
    }

    private void MoveProjectile()
    {
        transform.position = Vector2.MoveTowards(transform.position, _enemyTarget.transform.position, _moveSpeed * Time.deltaTime);

        float disToTarget = (_enemyTarget.transform.position - transform.position).magnitude;

        if (disToTarget < _minDisToDealDamage)
        {
            _enemyTarget.enemyHealth.DealDamage(_damage);

            turretOwner.ResetTurretProjectile();
            ObjectPooler.ReturnToPool(gameObject);
        }
    }

    public void SetEnemy(Enemy enemy)
    {
        _enemyTarget = enemy;
    }

    private void RotateProjectile()
    {
        Vector3 enemyPos = _enemyTarget.transform.position - transform.position;
        float angle = Vector3.SignedAngle(transform.up, enemyPos, transform.forward);

        transform.Rotate(0,0, angle);
    }
}
