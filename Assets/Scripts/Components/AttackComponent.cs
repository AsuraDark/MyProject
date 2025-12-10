using System.Collections;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackDelay;

    private Coroutine _coroutine;

    public void StartAttack(HealthComponent health)
    {
        _coroutine = StartCoroutine(Attack(health));
    }

    private IEnumerator Attack(HealthComponent health)
    {
        WaitForSeconds waitingTime = new WaitForSeconds(_attackDelay);

        while(enabled)
        {
            health.TakeDamage(_damage);

            yield return waitingTime;
        }
    }

    public void StopAttack()
    {
        StopCoroutine(_coroutine);
    }
}
