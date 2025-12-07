using System;
using UnityEngine;

public class HealthDetector : MonoBehaviour
{
    public event Action<HealthComponent> DetectedHealth;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HealthComponent>(out HealthComponent health))
        {
            DetectedHealth?.Invoke(health);
        }
    }
}
