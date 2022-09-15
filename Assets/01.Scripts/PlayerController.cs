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
        _moveDirection.x = _input.x * walkSpeed;

        if (_charactorController.below) //ont the ground
        {
            if (_startJump)
            {
                _startJump = false;
                _moveDirection.y = jumpSpeed;
                isJumping = true;
            }
        }
        else
        {
            if (_realeaseJump) //°øÁß¿¡.... 
            {
                _realeaseJump = false;
                if (_moveDirection.y > 0)
                {
                    _moveDirection.y *= 0.5f;
                }
            }
            _moveDirection.y -= gravity * Time.deltaTime;
        }

        _charactorController.Move(_moveDirection * Time.deltaTime);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
            _startJump = true;

        else if (context.canceled)
            _realeaseJump = true;
    }
}
