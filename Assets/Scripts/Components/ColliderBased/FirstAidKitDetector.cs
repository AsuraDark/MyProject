using System;
using UnityEngine;

public class FirstAidKitDetector : MonoBehaviour
{
    public event Action<float> DetectedFirstAidKit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CollectableItem firstAidKit))
        {
            if(firstAidKit.ItemType == ItemType.FirstAidKit)
            {
                DetectedFirstAidKit?.Invoke(firstAidKit.Value);
                Destroy(firstAidKit.gameObject);
            }
        }
    }
}