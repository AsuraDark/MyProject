using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AttackComponent), typeof(HealthComponent), typeof(Patroller))]
[RequireComponent(typeof(HeroKnightDetector))]
public class Frog : MonoBehaviour
{
    [SerializeField] private HealthDetector _healthDetector;
    [SerializeField] private HeroKnightDetector _heroKnightDetector;

    private AttackComponent _attackComponent;
    private HealthComponent _healthComponent;
    private Patroller _patroller;
    private Coroutine _coroutine;

    private HeroKnight _target;

    private void Awake()
    {
        _attackComponent = GetComponent<AttackComponent>();
        _healthComponent = GetComponent<HealthComponent>();
        _patroller = GetComponent<Patroller>();
        _coroutine = StartCoroutine(_patroller.StartPatroll());
    }

    private void OnEnable()
    {
        _healthDetector.DetectedHealth += _attackComponent.Attack;
        _heroKnightDetector.DetectedHeroKnight += SetTarget;
    }

    private void OnDisable()
    {
        _healthDetector.DetectedHealth -= _attackComponent.Attack;
        _heroKnightDetector.DetectedHeroKnight -= SetTarget;
    }

    private void SetTarget(HeroKnight target)
    {
        if(_target == null && target == null)
        {
            return;
        }

        _target = target;

        if(target != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(_patroller.StartFollowTarget(_target.transform.position));
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(_patroller.StartPatroll());
        }
    }

    
}
