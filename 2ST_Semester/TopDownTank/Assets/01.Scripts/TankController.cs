using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    private TankMover _tankmover;
    private AimTurret _aimTurret;
    private Turret[] _turrets;

    private void Awake()
    {
        _tankmover = GetComponentInChildren<TankMover>();
        _aimTurret = GetComponentInChildren<AimTurret>();
        _turrets = GetComponentsInChildren<Turret>();
    }

    public void HandleShoot()
    {
        foreach (var turret in _turrets)
            turret.SHot();
    }

    public void HandleMoveBody(Vector2 movementVector)
    {
        _tankmover.Move(movementVector);
    }

    public void HandleMoveTurret(Vector2 pointerPosition)
    {
        _aimTurret.Aim(pointerPosition);
    }
}
