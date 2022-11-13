using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] protected GameObject _objectToPool;
    [SerializeField] protected int _poolSize = 10;

    protected Queue<GameObject> _objectPool;

    public Transform _spawnedObjectParent;

    private void Awake()
    {
        _objectPool = new Queue<GameObject>();
    }

    public void Initialized(GameObject objectPool, int poolSize = 10)
    {
        this._objectToPool = objectPool;
        this._poolSize = poolSize;
    }

    public GameObject CreateObject()
    {
        CreateObjectParentIfNeeded();

        GameObject spawnedObject = null;
        if (_objectPool.Count < _poolSize)
        {
            spawnedObject = Instantiate(_objectToPool, transform.position, Quaternion.identity);
            spawnedObject.name = transform.root.name + "_" + _objectToPool.name + "_" + _objectPool.Count;
            spawnedObject.transform.SetParent(_spawnedObjectParent);
        }
        else
        {
            spawnedObject = _objectPool.Dequeue();
            spawnedObject.transform.position = transform.position;
            spawnedObject.transform.rotation = Quaternion.identity;
            spawnedObject.SetActive(true);
        }

        _objectPool.Enqueue(spawnedObject);
        return spawnedObject;
    }

    private void CreateObjectParentIfNeeded()
    {
        if (_spawnedObjectParent == null)
        {
            string name = "ObjectPool_" + _objectToPool.name;
            var parentObject = GameObject.Find(name);
            if (parentObject != null)
                _spawnedObjectParent = parentObject.transform;
            else
                _spawnedObjectParent = new GameObject(name).transform;
        }
    }
}
