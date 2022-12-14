using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _anim;
    [SerializeField] private AnimationCurve _animCurve;
    [SerializeField] private float _maxSpeed = 5;
    [SerializeField] private float _accelerationMaxTime = 1f;
    private float _buttonHoldTime;
    private bool _isMoving;


    public float moveSpeed = 5f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 moveVelocity = new Vector2(x, y).normalized * _maxSpeed;
        
        moveSpeed = CalulateSpeed(moveVelocity, _animCurve);

        _rigidbody.velocity = moveVelocity;
        
        AnimatorSet(moveVelocity);
    }

    private void AnimatorSet(Vector2 moveVelocity)
    {
        _anim.SetFloat("InputX", moveVelocity.x);
        _anim.SetFloat("InputY", moveVelocity.y);
    }

    private void SetAccelerationParamenters(Vector2 input)
    {
        if (input.magnitude > 0)
        {
            _isMoving = true;
            _buttonHoldTime += Time.deltaTime;
        }
        else
        {
            _isMoving = false;
            _buttonHoldTime = 0;
        }
    }

    private float CalulateSpeed(Vector2 input, AnimationCurve anmationCurve)
    {
        if (_isMoving)
        {
            float acceleration = _animCurve.Evaluate(_buttonHoldTime / _accelerationMaxTime);
            return _maxSpeed * acceleration;
        }
        else return 0;
    }

}
