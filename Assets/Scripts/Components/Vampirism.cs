using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _timeAction;
    [SerializeField] private float _recoveryRate;

    private List<HealthComponent> _targets = new List<HealthComponent>();
    private HealthComponent _currentTarget;

    private float _timer;
    private float _recoveryRateModificator;

    private bool _isSpellEnabled = false;

    private Coroutine _coroutine;

    public event Action<float> StealedHealth;
    public event Action<float> ChangedTimer;
    public event Action EnabledSpell;
    public event Action DisabledSpell;

    public float Timer
    {
        get { return _timer; }
    }

    public float TimeAction
    {
        get { return _timeAction; }
    }

    private void Start()
    {
        _timer = _timeAction;
        _recoveryRateModificator = _timeAction / _recoveryRate;
    }

    private void Update()
    {
        if (_isSpellEnabled)
        {
            ChangeTarget();
            _timer -= Time.deltaTime;
            ChangedTimer?.Invoke(_timer);

            if (_timer <= 0)
            {
                _isSpellEnabled = false;
                _currentTarget = null;
                DisabledSpell?.Invoke();

                if (_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                }
            }
        }

        if (_isSpellEnabled == false && _timer <= TimeAction)
        {
            _timer += Time.deltaTime * _recoveryRateModificator;
            ChangedTimer?.Invoke(_timer);
        }
    }

    private IEnumerator StealHealth(HealthComponent health)
    {
        while (enabled)
        {
            if (health.Value <= _damage)
            {
                health.TakeDamage(health.Value * Time.deltaTime);
                StealedHealth(health.Value * Time.deltaTime);
            }
            else
            {
                health.TakeDamage(_damage * Time.deltaTime);
                StealedHealth(_damage * Time.deltaTime);
            }

            yield return null;
        }
    }

    public void EnableSpell()
    {
        if (_isSpellEnabled == false && _timer >= _timeAction)
        {
            _isSpellEnabled = true;
            EnabledSpell?.Invoke();
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
            return;
        }

        else if (_targets.Count == 1 && (_currentTarget != _targets[_targets.Count - 1]))
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _currentTarget = _targets[_targets.Count - 1];
            _coroutine = StartCoroutine(StealHealth(_currentTarget));
        }

        else if (_targets.Count > 0 && _currentTarget != GetNearestTarget())
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _currentTarget = GetNearestTarget();
            _coroutine = StartCoroutine(StealHealth(_currentTarget));
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
