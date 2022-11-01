using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable id = collision.gameObject.GetComponent<IDamageable>();

        if (id != null)
        {
            id.OnDamage(1, gameObject, Vector2.up, 30f);
        }
    }
}
