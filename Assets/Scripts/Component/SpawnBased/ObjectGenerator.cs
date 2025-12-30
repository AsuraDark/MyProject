using System.Collections;
using UnityEngine;

public abstract class ObjectGenerator<T> : MonoBehaviour
{
    [SerializeField] protected float _delay;
    [SerializeField] protected float _lowerBound;
    [SerializeField] protected float _upperBound;
    [SerializeField] protected ObjectPool<T> _pool;

    private void Start()
    {
        StartCoroutine(GenerateEnemies());
    }

    protected IEnumerator GenerateEnemies()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    protected abstract void Spawn();
}