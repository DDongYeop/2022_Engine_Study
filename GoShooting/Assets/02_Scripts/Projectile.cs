using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    ObjectPooler bulletPooler;

    private void Start()
    {
        bulletPooler = GameObject.FindGameObjectWithTag("Player").GetComponent<ObjectPooler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //Destroy(collision.gameObject);
            collision.GetComponent<Enemy>().Die();
            //Destroy(gameObject);
            bulletPooler.ReturnObject(gameObject);
        }
    }
}
