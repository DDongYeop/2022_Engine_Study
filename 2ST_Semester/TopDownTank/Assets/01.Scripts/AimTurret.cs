using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTurret : MonoBehaviour
{
    [SerializeField] private float _turretRotationSpeed = 150f;

    public void Aim(Vector2 inputPointerPosition)
    {
        var turretDircetior = (Vector3)inputPointerPosition - transform.position;
        var desiredAngle = Mathf.Atan2(turretDircetior.y, turretDircetior.x) * Mathf.Rad2Deg;
        var rotationStep = _turretRotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, desiredAngle - 90), rotationStep);
    }   
}
