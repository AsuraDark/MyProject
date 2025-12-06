using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float _health;

    public void TakeDamage(float damage)
    {
        _health -= damage;
    }

    public void Heal(float heal)
    {
        _health += heal;
    }
}
