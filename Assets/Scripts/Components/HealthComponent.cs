using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private float _maxValue;

    public event Action<float> ChangedValue;

    public float Value
    {
        get { return _value; }
    }
    public float MinValue { private set; get; } = 0;
    public float MaxValue
    {
        get { return _maxValue; }
    }

    private void Start()
    {
        if (_value < MinValue)
        {
            _value = MinValue;
        }
        else if (_value > MaxValue)
        {
            _value = MaxValue;
        }

        ChangedValue(_value);
    }

    public void TakeDamage(float damage)
    {
        if (damage == 0)
        {
            return;
        }

        if (damage < 0)
        {
            damage = -damage;
        }

        _value -= damage;

        if (_value < MinValue)
        {
            _value = MinValue;
        }

        ChangedValue(_value);
    }

    public void Heal(float heal)
    {
        if (heal == 0)
        {
            return;
        }

        if (heal < 0)
        {
            heal = -heal;
        }

        _value += heal;

        if (_value > MaxValue)
        {
            _value = MaxValue;
        }

        ChangedValue(_value);
    }
}
