using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectPoolData 
{
    public GameObject prefab;
    public PoolObjectType type;
    public int prefabCount;
}
