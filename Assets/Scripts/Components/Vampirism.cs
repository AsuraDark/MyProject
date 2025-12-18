using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _damage;

    private List<HealthComponent> _targets = new List<HealthComponent>();
    private HealthComponent _currentTarget;

    private Coroutine _coroutine;

    public event Action<float> StealedHealth;

    public void Cast()
    {
        if(_coroutine != null)
        {
            _coroutine = null;
        }

        _coroutine = StartCoroutine(StealHealth());
    }

    public void StopCast()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator StealHealth()
    {
        while (enabled)
        {
            ChangeTarget();

            if (_currentTarget != null)
            {
                if (_currentTarget.Value <= _damage)
                {
                    _currentTarget.TakeDamage(_currentTarget.Value * Time.deltaTime);
                    StealedHealth(_currentTarget.Value * Time.deltaTime);
                }
                else
                {
                    _currentTarget.TakeDamage(_damage * Time.deltaTime);
                    StealedHealth(_damage * Time.deltaTime);
                }
            }
            
            yield return null;
        }
    }

    public void AddTarget(HealthComponent health)
    {
        _targets.Add(health);
    }

    public void RemoveTarget(HealthComponent health)
    {
        _targets.Remove(health);
    }

    private void ChangeTarget()
    {
        if (_targets.Count == 0)
        {
            if(_currentTarget != null)
            {
                _currentTarget = null;
            }

            return;
        }

        else if (_targets.Count == 1 && (_currentTarget != _targets[_targets.Count - 1]))
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _currentTarget = _targets[_targets.Count - 1];
            _coroutine = StartCoroutine(StealHealth());
        }

        else if (_targets.Count > 0 && _currentTarget != GetNearestTarget())
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _currentTarget = GetNearestTarget();
            _coroutine = StartCoroutine(StealHealth());
        }
    }

    private HealthComponent GetNearestTarget()
    {
        HealthComponent nearestTarget;
        int currentIndex = 0;

        nearestTarget = _targets[currentIndex];

        for (int i = currentIndex + 1; i < _targets.Count - 1; i++)
        {
            if (Vector3.Distance(transform.position, nearestTarget.transform.position) > Vector3.Distance(transform.position, _targets[i].transform.position))
            {
                nearestTarget = _targets[i];
            }
        }

        return nearestTarget;
    }
}
