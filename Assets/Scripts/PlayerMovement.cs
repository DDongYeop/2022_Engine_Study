using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumppw = 10f;

    private Vector2 _moveInput;
    private Rigidbody2D _rb;
    private Animator _animator;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Run();
        FlipSprite();
    }

    private void Run()
    {
        Vector2 _playerVelocity = new Vector2(_moveInput.x * speed, _rb.velocity.y);
        _rb.velocity = _playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(_rb.velocity.x) > Mathf.Epsilon;
        _animator.SetBool("IsRunning", playerHasHorizontalSpeed);
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(_rb.velocity.x) > Mathf.Epsilon;  //Epsilon은 0에 가장 가까운 숫자

        if (playerHasHorizontalSpeed)
            transform.localScale = new Vector2(Mathf.Sign(_rb.velocity.x), 1f); //Sign함수가 0이거나 양수이면 1로 반환
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            _rb.velocity += new Vector2(0f, jumppw);
        }
    }
}
