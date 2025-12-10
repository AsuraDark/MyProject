using UnityEngine;

[RequireComponent(typeof(HeroKnightMovement), typeof(InputReader), typeof(HeroKnightAnimation))]
[RequireComponent(typeof(HeroKnightAttack), typeof(HealthComponent))]
public class HeroKnight : MonoBehaviour
{
    [SerializeField] private CoinDetector _coinDetector;
    [SerializeField] private HealthDetector _healthDetector;
    [SerializeField] private FirstAidKitDetector _firstAidKitDetector;

    private HeroKnightMovement _heroKnightMovement;
    private HeroKnightAnimation _heroKnightAnimation;
    private HeroKnightAttack _heroKnightAttack;
    private InputReader _inputReader;
    private HealthComponent _healthComponent;

    private float _countCoin = 0;

    private void Awake()
    {
        _heroKnightMovement = GetComponent<HeroKnightMovement>();
        _inputReader = GetComponent<InputReader>();
        _heroKnightAnimation = GetComponent<HeroKnightAnimation>();
        _heroKnightAttack = GetComponent<HeroKnightAttack>();
        _healthComponent = GetComponent<HealthComponent>();
    }

    private void OnEnable()
    {
        _inputReader.ClickedAnyDirection += _heroKnightMovement.Move;
        _inputReader.ClickedAnyDirection += _heroKnightAnimation.PlayAnimationRun;
        _inputReader.ClickedUpDirection += _heroKnightMovement.Jump;
        _inputReader.ClickedUpDirection += _heroKnightAnimation.PlayAnimationJump;
        _inputReader.ClickedFButton += _heroKnightAnimation.PlayAnimationAttack;
        _inputReader.ClickedFButton += StartAttack;
        _coinDetector.DetectedCoin += IncreaseCountCoin;
        _healthDetector.DetectedHealth += Attack;
        _firstAidKitDetector.DetectedFirstAidKit += _healthComponent.Heal;
    }

    private void OnDisable()
    {
        _inputReader.ClickedAnyDirection -= _heroKnightMovement.Move;
        _inputReader.ClickedAnyDirection -= _heroKnightAnimation.PlayAnimationRun;
        _inputReader.ClickedUpDirection -= _heroKnightMovement.Jump;
        _inputReader.ClickedUpDirection -= _heroKnightAnimation.PlayAnimationJump;
        _inputReader.ClickedFButton -= _heroKnightAnimation.PlayAnimationAttack;
        _coinDetector.DetectedCoin -= IncreaseCountCoin;
        _healthDetector.DetectedHealth -= Attack;
        _firstAidKitDetector.DetectedFirstAidKit -= _healthComponent.Heal;
    }

    private void Start()
    {
        _healthDetector.gameObject.SetActive(false);
    }
    
    public void StartAttack()
    {
        _healthDetector.gameObject.SetActive(true);
    }

    private void Attack(HealthComponent health)
    {
        _heroKnightAttack.Attack(health);
        _healthDetector.gameObject.SetActive(false);
    }

    private void IncreaseCountCoin(float countCoin)
    {
        _countCoin += countCoin;
        Debug.LogFormat($"Количество монет:{_countCoin}");
    }
}