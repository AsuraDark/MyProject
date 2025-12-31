using System;
using UnityEngine;

public class BirdCollisionDetector : MonoBehaviour
{
    public event Action<Interactable> CollisionDetected;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Interactable interactable))
        {
            CollisionDetected?.Invoke(interactable);
        }
    }
}
