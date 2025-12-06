using UnityEngine;

public class ButtonAttack : ButtonHealthChanger
{
    [SerializeField] private float _damage;

    protected override void ChangeHealth()
    {
        _healthComponent.TakeDamage(_damage);
    }
}