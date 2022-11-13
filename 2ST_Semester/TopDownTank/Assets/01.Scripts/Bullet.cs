using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private int _damage = 5;
    [SerializeField] private float _maxDistance = 10;

    private Vector2 _startPosition;
    private float _conquaredDistance = 0;
    private Rigidbody2D _rigidbody;

    private void Awake() 
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Initializes()
    {
        _startPosition = transform.position;
        _rigidbody.velocity = transform.up * _speed;
    }

    private void Update() 
    {
        _conquaredDistance = Vector2.Distance(transform.position, _startPosition);
        if (_conquaredDistance > _maxDistance)
            DisableObject();
    }

    private void DisableObject()
    {
        _rigidbody.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    //충돌 했을떄 비활성화 
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Collision name : " + other.name);
        var damageble = other.GetComponent<Damageable>();
        if (damageble != null)
            damageble.OnHit(_damage);
        DisableObject();
    }
}
