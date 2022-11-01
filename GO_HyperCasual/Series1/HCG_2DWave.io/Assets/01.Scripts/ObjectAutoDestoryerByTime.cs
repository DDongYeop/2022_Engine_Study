using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAutoDestoryerByTime : MonoBehaviour
{
    [SerializeField] private float _destroyTime;

    private void Awake()
    {
        Destroy(gameObject, _destroyTime);
    }
}
