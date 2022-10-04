using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    [SerializeField] private Transform _projectileSpawnPos;
    private ObjectPooler _pooler;

    private Projectile _currentProjectileLoaded;
    private Turret _turret;

    private void Start()
    {
        _pooler = GetComponent<ObjectPooler>();
        _turret = GetComponent<Turret>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            LoadProjectile();

        if (_turret.currentEnemyTarget != null && _currentProjectileLoaded != null && _turret.currentEnemyTarget.enemyHealth.currentHealth > 0f)
        {
            _currentProjectileLoaded.transform.parent = null;
            _currentProjectileLoaded.SetEnemy(_turret.currentEnemyTarget);
        }
    }

    private void LoadProjectile()
    {
        GameObject newInstance = _pooler.GetInstanceFromPool();
        newInstance.transform.parent = _projectileSpawnPos;
        newInstance.transform.SetParent(_projectileSpawnPos);

        _currentProjectileLoaded = newInstance.GetComponent<Projectile>();
        newInstance.SetActive(true);
    }
}
