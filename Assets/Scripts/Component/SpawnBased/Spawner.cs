using System.Collections;
using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : Interactable
{
    [SerializeField] protected T Prefab;
    [SerializeField] protected float Delay;

    protected ObjectPool<T> Pool;

    public abstract void Spawn();
}