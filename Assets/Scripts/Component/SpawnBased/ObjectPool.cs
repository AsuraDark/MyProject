using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour
{
    [SerializeField] protected T _prefab;

    protected Queue<T> _pool;

    public IEnumerable<T> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<T>();
    }

    public abstract T GetObject();

    public abstract void PutObject(T newObject);

    public void Reset()
    {
        _pool.Clear();
    }
}