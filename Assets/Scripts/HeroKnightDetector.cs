using System;
using UnityEngine;

public class HeroKnightDetector : MonoBehaviour
{
    public event Action<HeroKnight> DetectedHeroKnight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<HeroKnight>(out HeroKnight heroKnight))
        {
            DetectedHeroKnight?.Invoke(heroKnight);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HeroKnight>(out HeroKnight heroKnight))
        {
            DetectedHeroKnight?.Invoke(null);
        }
    }
}
