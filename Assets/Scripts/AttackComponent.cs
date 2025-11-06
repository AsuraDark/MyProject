using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackDelay;

    private float _time = 0;

    public void Attack(HealthComponent health)
    {
        if (Time.time >= _time || _time == 0)
        {
            if (_damage < 0)
            {
                health.TakeDamage(-_damage);
            }
            else
            {
                health.TakeDamage(_damage);
            }

            _time = Time.time + _attackDelay;
        }
    }
}
