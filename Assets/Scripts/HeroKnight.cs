using UnityEngine;

[RequireComponent(typeof(HeroKnightMovement), typeof(InputReader), typeof(HeroKnightAnimation))]
[RequireComponent(typeof(AttackComponent), typeof(HealthComponent))]
public class HeroKnight : MonoBehaviour
{
    [SerializeField] private CoinDetector _coinDetector;
    [SerializeField] private HealthDetector _healthDetector;
    [SerializeField] private FirstAidKitDetector _firstAidKitDetector;

    private HeroKnightMovement _heroKnightMovement;
    private HeroKnightAnimation _heroKnightAnimation;
    private InputReader _inputReader;
    private AttackComponent _attackComponent;
    private HealthComponent _healthComponent;

    private int _countCoin = 0;

    private void Awake()
    {
        _heroKnightMovement = GetComponent<HeroKnightMovement>();
        _inputReader = GetComponent<InputReader>();
        _heroKnightAnimation = GetComponent<HeroKnightAnimation>();
        _attackComponent = GetComponent<AttackComponent>();
        _healthComponent = GetComponent<HealthComponent>();
    }

    private void OnEnable()
    {
        _inputReader.ClickedAnyDirection += _heroKnightMovement.Move;
        _inputReader.ClickedAnyDirection += _heroKnightAnimation.PlayAnimationRun;
        _inputReader.ClickedUpDirection += _heroKnightMovement.Jump;
        _inputReader.ClickedUpDirection += _heroKnightAnimation.PlayAnimationJump;
        _coinDetector.DetectedCoin += IncreaseCountCoin;
        _healthDetector.DetectedHealth += _attackComponent.Attack;
        _firstAidKitDetector.DetectedFirstAidKit += _healthComponent.Heal;
    }

    private void OnDisable()
    {
        _inputReader.ClickedAnyDirection -= _heroKnightMovement.Move;
        _inputReader.ClickedAnyDirection -= _heroKnightAnimation.PlayAnimationRun;
        _inputReader.ClickedUpDirection -= _heroKnightMovement.Jump;
        _inputReader.ClickedUpDirection -= _heroKnightAnimation.PlayAnimationJump;
        _coinDetector.DetectedCoin -= IncreaseCountCoin;
        _healthDetector.DetectedHealth -= _attackComponent.Attack;
        _firstAidKitDetector.DetectedFirstAidKit -= _healthComponent.Heal;
    }

    private void IncreaseCountCoin()
    {
        _countCoin++;
        Debug.LogFormat("Количество монет:{0}", _countCoin);
    }
}