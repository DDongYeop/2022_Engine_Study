using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 10;
    public float gravity = 20f;

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


    }
}
