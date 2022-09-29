using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 10;
    public float gravity = 20f;
    public float jumpSpeed = 15f;

    //player state
    public bool isJumping;

    private bool _startJump;
    private bool _realeaseJump;

    private Vector2 _input;
    private Vector2 _moveDirection;
    private CharactorController2D _charactorController;

    private void Awake()
    {
        _charactorController = GetComponent<CharactorController2D>();
    }

    private void Update()
    {
        PlayerMove();
        SpriteFlip();
        PlayerJump();
    }
    
    private void GravityCalculation()
    {
        if (_moveDirection.y > 0f && _charactorController.above)
        {
            _moveDirection.y = 0f;
        }
        _moveDirection.y -= gravity * Time.deltaTime;
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _startJump = true;
            _realeaseJump = false;
        }

        else if (context.canceled)
        {
            _startJump = false;
            _realeaseJump = true;
        }
    }

    private void SpriteFlip()
    {
        if (_input.x > 0)
            transform.localScale = Vector3.one;
        else if (_input.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = transform.localScale;
    }

    private void PlayerJump()
    {
        if (_charactorController.below) //ont the ground
        {
            _moveDirection.y = 0;

            if (_startJump)
            {
                _startJump = false;
                _moveDirection.y = jumpSpeed;
                isJumping = true;
                _charactorController.DisableGroundCheck(0.1f);
            }
        }
        else
        {
            if (_realeaseJump) //���߿�.... 
            {
                _realeaseJump = false;
                if (_moveDirection.y > 0)
                {
                    _moveDirection.y *= 0.5f;
                }
            }
            GravityCalculation();
        }

        _charactorController.Move(_moveDirection * Time.deltaTime);

        /*if (_charactorController.above)
            _realeaseJump = true;*/
    }

    private void PlayerMove()
    {
        _moveDirection.x = _input.x * walkSpeed;
    }
}
