using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public TankMover tankMover;
    public AimTurret aimTurret;
    public Turret[] turrets;

    private void Awake()
    {
        tankMover = GetComponentInChildren<TankMover>();
        aimTurret = GetComponentInChildren<AimTurret>();
        turrets=GetComponentsInChildren<Turret>();
    }

    public void HandleShoot()
    {
        foreach(var turret in turrets)
        {
            turret.Shoot();
        }
    }

    public void HandleMoveBody(Vector2 movementVector)
    {
        tankMover.Move(movementVector);
    }

    public void HandleMoveTurret(Vector2 pointerPosition)
    {
        aimTurret.Aim(pointerPosition);
    }
    
}
