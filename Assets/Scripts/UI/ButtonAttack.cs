using UnityEngine;

public class ButtonAttack : ButtonHealthChanger
{
    [SerializeField] private float _damage;

    protected override void ChangeHealth()
    {
        HealthComponent.TakeDamage(_damage);
    }
}