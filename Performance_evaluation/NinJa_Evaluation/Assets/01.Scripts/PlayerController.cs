using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    [SerializeField] private AnimationCurve _animatorationCurve;
    [SerializeField] private float _maxspeed = 5;
    [SerializeField] private float _accelerationMaxTime = 1f;
    private float _buttonHoldTime;
    private bool _isMoving;


    public float speed = 5f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        SetAccelerationParamenters(dir);
        speed = Calulatespeed(dir, _animatorationCurve);
        
        _rigidbody.velocity = dir.normalized * _maxspeed;

        AnimatorSet(dir);
    }

    private void AnimatorSet(Vector2 dir)
    {
        _animator.SetFloat("InputX", dir.x);
        _animator.SetFloat("InputY", dir.y);
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

    private float Calulatespeed(Vector2 input, AnimationCurve anmationCurve)
    {
        if (_isMoving)
        {
            float acceleration = _animatorationCurve.Evaluate(_buttonHoldTime / _accelerationMaxTime);
            return _maxspeed * acceleration;
        }
        else return 0;
    }

}

//Firebase
