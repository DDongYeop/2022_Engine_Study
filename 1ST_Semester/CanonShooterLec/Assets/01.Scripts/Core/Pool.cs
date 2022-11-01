using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    private Stack<T> _pool = new Stack<T>();
    private T _prefab; //오리지널 프리펩 저장, 그래야 모자랄때 쓸 수 있음
    private Transform _parnet; // 부모도 저장, 그래야 모자랄떄 만든걸 부모 설정이 가능

    public Pool(T prefab, Transform parnet, int count = 10)
    {
        _prefab = prefab;
        _parnet = parnet;

        for (int i = 0; i < count; i++)
        {
            T obj = GameObject.Instantiate(prefab, parnet);
            obj.gameObject.name = obj.gameObject.name.Replace("(Clone)",""); // 클론이라고 붙은 부분 제거
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
            obj.gameObject.name = obj.gameObject.name.Replace("(Clone)", ""); // 클론이라고 붙은 부분 제거
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
