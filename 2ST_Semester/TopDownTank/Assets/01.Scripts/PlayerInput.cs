using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent OnShoot = new UnityEvent();
    public UnityEvent<Vector2> OnMoveBody = new UnityEvent<Vector2>();
    public UnityEvent<Vector2> OnMoveTurret = new UnityEvent<Vector2>();

    private Camera _maincamera;

    private void Awake() 
    {
        _maincamera = Camera.main;
    }

    private void Update() 
    {
        GetbodyMovement();
        GetTurretMovement();
        GetShootingInput();
    }

    private void GetbodyMovement()
    {
        if(Input.GetMouseButtonDown(0))
        {
            OnShoot?.Invoke();
        }
    }

    private void GetTurretMovement()
    {
        OnMoveTurret?.Invoke(GetMousePosition());
    }

    private Vector2 GetMousePosition()
    {
        Vector3 mousePosition= Input.mousePosition;
        mousePosition.z = _maincamera.nearClipPlane;
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        return mouseWorldPosition;
    }

    private void GetShootingInput()
    {
        Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        OnMoveBody?.Invoke(movementVector.normalized);
    }
}
