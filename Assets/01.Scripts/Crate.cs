using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour, IDamageable
{
    [SerializeField] private BrokenCrate _brokenPrefab;

    public void OnDamage(int damage, GameObject damageDealer, Vector2 dir, float force)
    {
        BoxExlposion(dir, force);
    }

    private void BoxExlposion(Vector2 dir, float force)
    {
        BrokenCrate bc = Instantiate(_brokenPrefab, transform.position, Quaternion.identity);
        bc.AddForce(dir, force);
        Destroy(bc.gameObject, 2f);
        Destroy(gameObject);
    }
}
