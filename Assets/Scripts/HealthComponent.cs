using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float _health;
    public float MinHealth { private set; get; } = 0;
    public float MaxHealth { private set; get; } = 100;

    public event Action<float> ChangedHealth;

    private void Start()
    {
        if (_health < MinHealth)
        {
            _health = MinHealth;
        }
        else if (_health > MaxHealth)
        {
            _health = MaxHealth;
        }

        ChangedHealth(_health);
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health < MinHealth)
        {
            _health = MinHealth;
        }

        ChangedHealth(_health);
    }

    public void Heal(float heal)
    {
        _health += heal;

        if (_health > MaxHealth)
        {
            _health = MaxHealth;
        }

        ChangedHealth(_health);
    }
}
