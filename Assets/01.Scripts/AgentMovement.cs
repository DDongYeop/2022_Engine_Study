using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentMovement : MonoBehaviour
{
    [SerializeField] private MovementDataSO _movementSO;
    private Rigidbody2D _rigidbody;

    protected float _currentVelocity = 0;
    protected Vector2 _movementDIrection;

    public UnityEvent<float> OnVelocityChange;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveAgent(Vector2 moveInput)
    {
        //이건 키가 눌렸다
        if (moveInput.sqrMagnitude > 0)
        {
            if (Vector2.Dot(moveInput, _movementDIrection) < 0)
            {
                _currentVelocity = 0;
            }
            _movementDIrection = moveInput.normalized;
        }
        _currentVelocity = CalculateSpeed(moveInput);
    }

    private float CalculateSpeed(Vector2 moveInput)
    {
        if (moveInput.sqrMagnitude > 0)
        {
            _currentVelocity += _movementSO.acceleration * Time.deltaTime;
        }
        else
        {
            _currentVelocity -= _movementSO.deAcceleration * Time.deltaTime;
        }

        return Mathf.Clamp(_currentVelocity, 0, _movementSO.maxSpeed);
    }

    private void FixedUpdate()
    {
        OnVelocityChange?.Invoke(_currentVelocity);
        _rigidbody.velocity = _movementDIrection * _currentVelocity;
    }

    public void StopImmdiatelly()
    {
        _currentVelocity = 0;
        _rigidbody.velocity = Vector2.zero;
    }
}
