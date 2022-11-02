using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //player state
    [Header("Player States")]
    public bool isJumping;
    public bool isDashing; 

    private Vector2 _input;

    private CharactorController2D _charactorController;


    private void Awake()
    {
        _charactorController = GetComponent<CharactorController2D>();
    }

    private void Update()
    {

    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        
    }
}
