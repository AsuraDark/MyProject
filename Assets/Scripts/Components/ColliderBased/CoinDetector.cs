using System;
using UnityEngine;

public class CoinDetector : MonoBehaviour
{
    public event Action DetectedCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Coin>(out Coin coin))
        {
            Destroy(coin.gameObject);
            DetectedCoin?.Invoke();
        }
    }
}
