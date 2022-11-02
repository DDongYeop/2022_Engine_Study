using GlobalType;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController2D : MonoBehaviour
{

    //flags
    public bool below;
    public bool above;
    public bool right;
    public bool left;
     
    private Vector2 _moveAmount;
    private Vector2 _currentPosition;
    private Vector2 _lastPosition;

    private Rigidbody2D _rigidbody;
    private CapsuleCollider2D _capsuleCollider;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
    

    }   
}