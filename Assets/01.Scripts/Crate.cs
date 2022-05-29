using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour, IDamageable
{
    //[SerializeField] private BrokenCrate _brokenPrefab;

    public Action OnExplosion = null;

    public void OnDamage(int damage, GameObject damageDealer, Vector2 dir, float force)
    {
        BoxExlposion(dir, force);
        OnExplosion?.Invoke();
    }

    private void BoxExlposion(Vector2 dir, float force)
    {
        BrokenCrate bc = PoolManager.Instance.Pop("BrokenCrate") as BrokenCrate;
        bc.transform.position = transform.position;
        bc.AddForce(dir, force);
        //Destroy(bc.gameObject, 2f);
        Destroy(gameObject);
    }
}
