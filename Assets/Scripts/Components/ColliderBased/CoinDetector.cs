using System;
using UnityEngine;

public class CoinDetector : MonoBehaviour
{
    public event Action<float> DetectedCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CollectableItem coin))
        {
            if (coin.ItemType == ItemType.Coin)
            {
                DetectedCoin?.Invoke(coin.Value);
                coin.Collect();
            }
        }
    }
}
