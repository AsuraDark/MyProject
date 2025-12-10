using UnityEngine;

[RequireComponent(typeof(AttackComponent), typeof(HealthComponent), typeof(Patroller))]
[RequireComponent(typeof(HeroKnightDetector), typeof(FollowTargeter))]
public class Frog : MonoBehaviour
{
    [SerializeField] private HealthDetector _healthDetector;
    [SerializeField] private HeroKnightDetector _heroKnightDetector;

    private AttackComponent _attackComponent;
    private HealthComponent _healthComponent;
    private Patroller _patroller;
    private FollowTargeter _followTargeter;
    private Coroutine _coroutine;

    private HeroKnight _target;

    private void Awake()
    {
        _attackComponent = GetComponent<AttackComponent>();
        _healthComponent = GetComponent<HealthComponent>();
        _patroller = GetComponent<Patroller>();
        _followTargeter = GetComponent<FollowTargeter>();
        _coroutine = StartCoroutine(_patroller.StartPatroll());
    }

    private void OnEnable()
    {
        _healthDetector.DetectedHealth += _attackComponent.StartAttack;
        _healthDetector.MissedHealth += _attackComponent.StopAttack;
        _heroKnightDetector.DetectedHeroKnight += SetTarget;
        _heroKnightDetector.MissedHeroKnight += ResetTarget;
        _heroKnightDetector.MissedHeroKnight += StarPatroll;
    }

    private void OnDisable()
    {
        _healthDetector.DetectedHealth -= _attackComponent.StartAttack;
        _healthDetector.MissedHealth -= _attackComponent.StopAttack;
        _heroKnightDetector.DetectedHeroKnight -= SetTarget;
        _heroKnightDetector.MissedHeroKnight -= ResetTarget;
        _heroKnightDetector.MissedHeroKnight -= StarPatroll;
    }

    private void SetTarget(HeroKnight target)
    {
        _target = target;

        StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(_followTargeter.StartFollowTarget(_target.transform.position));
    }

    private void StarPatroll()
    {
        StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(_patroller.StartPatroll());
    }

    private void ResetTarget()
    {
        _target = null;
    }
}
