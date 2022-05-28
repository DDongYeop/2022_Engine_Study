using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    private Stack<T> _pool = new Stack<T>();
    private T _prefab; //�������� ������ ����, �׷��� ���ڶ��� �� �� ����
    private Transform _parnet; // �θ� ����, �׷��� ���ڶ��� ����� �θ� ������ ����

    public Pool(T prefab, Transform parnet, int count = 10)
    {
        _prefab = prefab;
        _parnet = parnet;

        for (int i = 0; i < count; i++)
        {
            T obj = GameObject.Instantiate(prefab, parnet);
            obj.gameObject.name = obj.gameObject.name.Replace("(Clone)",""); // Ŭ���̶�� ���� �κ� ����
            obj.gameObject.SetActive(false);
            _pool.Push(obj);
        }
    }

    public T Pop()
    {
        T obj = null;
        if (_pool.Count <= 0)
        {
            obj = GameObject.Instantiate(_prefab, _parnet);
            obj.gameObject.name = obj.gameObject.name.Replace("(Clone)", ""); // Ŭ���̶�� ���� �κ� ����
        }
        else
        {
            obj = _pool.Pop();
            obj.gameObject.SetActive(true);
        }
        return obj;
    }

    public void Push(T obj)
    {
        obj.gameObject.SetActive(false);
        _pool.Push(obj);
    }
}
