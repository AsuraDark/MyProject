using System;
using UnityEngine;

public class Enemy : Interactable
{
    public event Action<Enemy> ObjectDestroyed;

    public void DestroyObj()
    {
        ObjectDestroyed?.Invoke(this);
    }
}
