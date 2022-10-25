using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUpgrade : MonoBehaviour
{
    [SerializeField] private int upgradeInitalCost;
    [SerializeField] private int upgradeCostIncremental;
    [SerializeField] private float damageIncremental;


    private TurretProjectile _turretProjectile;

    private void Start()
    {
        _turretProjectile = GetComponent<TurretProjectile>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            UpgradeTurret();
    }

    private void UpgradeTurret()
    {
        _turretProjectile.Damage += damageIncremental;
    }
}
