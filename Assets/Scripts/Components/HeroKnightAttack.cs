using UnityEngine;

public class HeroKnightAttack : MonoBehaviour
{
    [SerializeField] private float _damage;

    public void Attack(HealthComponent health)
    {
        health.TakeDamage(_damage);
    }
}
