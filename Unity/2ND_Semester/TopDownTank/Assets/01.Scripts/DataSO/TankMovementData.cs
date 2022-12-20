using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewTankMovementData", menuName ="Data/TankMovementData")]
public class TankMovementData : ScriptableObject
{
    public float maxSpeed = 70;
    public float rotationSpeed = 200;
    public float acceleration = 70;
    public float deacceleration = 50;
}
