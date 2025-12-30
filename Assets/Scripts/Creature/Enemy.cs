using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IInteractable
{
    public event Action<Enemy> ObjectDestroyed;

    public void DestroyObject(Enemy enemy)
    {
        ObjectDestroyed?.Invoke(enemy);
    }
}
