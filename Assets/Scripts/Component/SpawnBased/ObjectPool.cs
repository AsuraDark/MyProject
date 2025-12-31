using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Interactable
{
    private Queue<T> _pool;

    public int Length => _pool.Count;

    public void Init()
    {
        _pool = new Queue<T>();
    }

    public T GetObject()
    {
        T newObject;

        newObject = _pool.Dequeue();

        return newObject;
    }

    public void PutObject(T newObject)
    {
        _pool.Enqueue(newObject);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}