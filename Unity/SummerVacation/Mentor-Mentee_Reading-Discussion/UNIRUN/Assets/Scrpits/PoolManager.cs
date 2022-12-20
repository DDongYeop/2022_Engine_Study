using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance = null;

    private Dictionary<string, Stack<GameObject>> _pools = new Dictionary<string, Stack<GameObject>>();

    private GameObject _prefab;
    private Transform _trmParent;

    public void CreatePool(GameObject prefab, Transform trmParnet, int count = 10)
    {
        _prefab = prefab;
        _trmParent = trmParnet;

        _pools.Add(_prefab.name, new Stack<GameObject>());

        for (int i = 0; i < count; i++)
        {
            GameObject obj;
            obj = Instantiate(_prefab, _trmParent);
            obj.name = obj.name.Replace("(Clone)", "");
            obj.SetActive(false);
            _pools[obj.name].Push(obj);
        }
    }

    public GameObject Pop(string prefabName)
    {
        if (_pools.ContainsKey(prefabName) == false)
        {
            Debug.LogError("prefabName을 가진 오브젝트가 풀 안에 없습니다");
        }

        GameObject obj = null;
        if (_pools[prefabName].Count <= 0)
        {
            obj = Instantiate(_prefab, _trmParent);
            obj.name = obj.name.Replace("(Clone)", "");
        }
        else
        {
            obj = _pools[prefabName].Pop();
            obj.SetActive(true);
        }

        return obj;
    }

    public void Push(GameObject obj)
    {
        obj.SetActive(false);
        _pools[obj.name].Push(obj);
    }
}
