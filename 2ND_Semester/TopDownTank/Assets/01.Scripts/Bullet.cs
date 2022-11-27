using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletData bulletData;

    private Vector2 startPosition;
    private float conquaredDistance = 0;
    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Initializes(BulletData bulletData)
    {
        this.bulletData = bulletData;
        startPosition = transform.position;
        rigidbody.velocity = transform.up * bulletData.speed;
    }

    private void Update()
    {
        conquaredDistance = Vector2.Distance(transform.position, startPosition);
        if(conquaredDistance > bulletData.maxDistance)
        {
            DisableObject();
        }
    }

    private void DisableObject()
    {
        rigidbody.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    //충돌하였을 때 비활성화시키기
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision name: " + collision.name);
        var damagable = collision.GetComponent<Damagable>();
        if(damagable != null) damagable.Hit(bulletData.damage);
        DisableObject();
    }
}
