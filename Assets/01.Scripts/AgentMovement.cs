using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentMovement : MonoBehaviour
{
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
        _movementDIrection = moveInput.normalized  * 5f;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _movementDIrection;
    }
}
