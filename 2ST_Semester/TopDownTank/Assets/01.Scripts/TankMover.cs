using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 70f;
    [SerializeField] private float _rotationSpeed = 200f;
    [SerializeField] private float _acceleration = 70f;
    [SerializeField] private float _deacceleration = 50f;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _movementVector;
    private float _currentSpeed = 0;
    private float _currentForewardDirection = 1;

    private void Awake() 
    {
        _rigidbody2D = GetComponentInParent<Rigidbody2D>();
    }

    public void Move(Vector2 movementVector)
    {
        this._movementVector = movementVector;
        CalculateSpeed(movementVector);
        if (movementVector.y > 0)
            _currentForewardDirection = 1;
        else if(movementVector.y < 0)
            _currentForewardDirection = -1;
    }

    private void CalculateSpeed(Vector2 movementVector)
    {
        if (Mathf.Abs(movementVector.y) > 0)
            _currentSpeed += _acceleration * Time.deltaTime;
        else
            _currentSpeed -= _deacceleration * Time.deltaTime;

        _currentSpeed = Mathf.Clamp(_currentSpeed, 0, _maxSpeed);
    }

    private void FixedUpdate() 
    {
        _rigidbody2D.velocity = (Vector2)transform.up * _currentSpeed * _currentForewardDirection * Time.fixedDeltaTime;
        _rigidbody2D.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -_movementVector.x * _rotationSpeed * Time.fixedDeltaTime));
    }
}
