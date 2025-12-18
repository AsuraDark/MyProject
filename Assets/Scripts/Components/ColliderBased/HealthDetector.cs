using System;
using UnityEngine;

public class HealthDetector : MonoBehaviour
{
    public event Action<HealthComponent> DetectedHealth;
    public event Action<HealthComponent> MissedHealth;
    [SerializeField] private LayerMask _layerMask;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthComponent health) && ((_layerMask.value & (1 << collision.gameObject.layer) ) != 0))
        {
            DetectedHealth?.Invoke(health);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthComponent health) && ((_layerMask.value & (1 << collision.gameObject.layer)) != 0))
        {
            MissedHealth?.Invoke(health);
        }
    }
}
