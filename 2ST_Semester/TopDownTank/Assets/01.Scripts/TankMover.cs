using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 70f;
    [SerializeField] private float _rotationSpeed = 200f;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _movementVector;

    private void Awake() 
    {
        _rigidbody2D = GetComponentInParent<Rigidbody2D>();    
    }

    public void Move(Vector2 movementVector)
    {
        this._movementVector = movementVector;
    }

    private void FixedUpdate() 
    {
        _rigidbody2D.velocity = (Vector2)transform.up * _movementVector.y * _maxSpeed * Time.fixedDeltaTime;
        _rigidbody2D.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -_movementVector.x * _rotationSpeed * Time.fixedDeltaTime));
    }
}
