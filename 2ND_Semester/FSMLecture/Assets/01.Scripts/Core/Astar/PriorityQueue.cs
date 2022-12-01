using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue<T> where T: IComparable<T>
{
    public List<T> _heap = new List<T>();

    public int Count => _heap.Count;
    
    public T Contains(T t)
    {
        int idx = _heap.IndexOf(t);
        if (idx < 0) return default(T);
        return _heap[idx];
    }

    public void Push(T data)
    {

    }

    public T Pop()
    {
        return default(T);
    }
    //Peek Pop
    public T Peek()
    {
        return default(T);
    }
}
