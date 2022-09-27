using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject _itemEffect;

    public void Exit()
    {
        Instantiate(_itemEffect, transform.position, Quaternion.identity);  
        Destroy(gameObject);
    }
}
