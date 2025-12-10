using System;
using UnityEngine;

public class HeroKnightDetector : MonoBehaviour
{
    public event Action<HeroKnight> DetectedHeroKnight;
    public event Action MissedHeroKnight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out HeroKnight heroKnight))
        {
            DetectedHeroKnight?.Invoke(heroKnight);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HeroKnight heroKnight))
        {
            MissedHeroKnight?.Invoke();
        }
    }
}
