using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField] private ObjectPoolData[] objectPoolDatas;

    private readonly Dictionary<PoolObjectType, ObjectPoolData> poolObjectDataMap = new();

    private readonly Dictionary<PoolObjectType, Queue<GameObject>> pool = new Dictionary<PoolObjectType, Queue<GameObject>>();

    private void Awake() 
    {
        if (Instance == null)
            Instance = this;
    }

    private void Init()
    {
        foreach(var data in objectPoolDatas)
            poolObjectDataMap.Add(data.type, data);

        foreach (var data in poolObjectDataMap)
        {
            pool.Add(data.Key, new Queue<GameObject>());

            // Count 생성
        }
    }
}
