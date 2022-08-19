using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : PoolAbleMono
{
    private Stack<T> _pool = new Stack<T>();
    private T _prefab; //�������� ������ ����
    private Transform _parnet; //�θ� ����

    public Pool(T prefab, Transform parent, int count = 10)
    {
        _prefab = prefab;
        _parnet = parent;

        for (int i = 0; i < count; i++)
        {
            T obj = GameObject.Instantiate(prefab, parent);
            obj.gameObject.name = obj.gameObject.name.Replace("(Clone)", ""); // Clone�̸��� �������� ���
        }
    }
}
