using System;
using UnityEngine;

public class FirstAidKitDetector : MonoBehaviour
{
    public event Action<float> DetectedFirstAidKit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<FirstAidKit>(out FirstAidKit firstAidKit))
        {
            DetectedFirstAidKit?.Invoke(firstAidKit.Heal);
            Destroy(firstAidKit.gameObject);
        }
    }
}