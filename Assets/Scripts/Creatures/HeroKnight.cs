using UnityEngine;

[RequireComponent(typeof(HeroKnightMovement), typeof(InputReader), typeof(HeroKnightAnimation))]
[RequireComponent(typeof(HeroKnightAttack), typeof(HealthComponent), typeof(Vampirism))]
public class HeroKnight : MonoBehaviour
{
    [SerializeField] private CoinDetector _coinDetector;
    [SerializeField] private HealthDetector _attackRange;
    [SerializeField] private HealthDetector _vampirismRange;
    [SerializeField] private FirstAidKitDetector _firstAidKitDetector;

    private HeroKnightMovement _heroKnightMovement;
    private HeroKnightAnimation _heroKnightAnimation;
    private HeroKnightAttack _heroKnightAttack;
    private InputReader _inputReader;
    private HealthComponent _healthComponent;
    private Vampirism _vampirism;

    private float _countCoin = 0;

    private void Awake()
    {
        _heroKnightMovement = GetComponent<HeroKnightMovement>();
        _inputReader = GetComponent<InputReader>();
        _heroKnightAnimation = GetComponent<HeroKnightAnimation>();
        _heroKnightAttack = GetComponent<HeroKnightAttack>();
        _healthComponent = GetComponent<HealthComponent>();
        _vampirism = GetComponent<Vampirism>();
    }

    private void OnEnable()
    {
        _inputReader.ClickedAnyDirection += _heroKnightMovement.Move;
        _inputReader.ClickedAnyDirection += _heroKnightAnimation.PlayAnimationRun;
        _inputReader.ClickedUpDirection += _heroKnightMovement.Jump;
        _inputReader.ClickedUpDirection += _heroKnightAnimation.PlayAnimationJump;
        _inputReader.ClickedFButton += _heroKnightAnimation.PlayAnimationAttack;
        _inputReader.ClickedFButton += StartAttack;
        _inputReader.ClickedRButton += _vampirism.EnableSpell;
        _coinDetector.DetectedCoin += IncreaseCountCoin;
        _attackRange.DetectedHealth += Attack;
        _firstAidKitDetector.DetectedFirstAidKit += _healthComponent.Heal;
        _vampirismRange.DetectedHealth += _vampirism.AddTarget;
        _vampirismRange.MissedHealth += _vampirism.RemoveTarget;
        _vampirism.StealedHealth += _healthComponent.Heal;
        _vampirism.EnabledSpell += EnableVampirism;
        _vampirism.DisabledSpell += DisableVampirism;
    }

    private void OnDisable()
    {
        _inputReader.ClickedAnyDirection -= _heroKnightMovement.Move;
        _inputReader.ClickedAnyDirection -= _heroKnightAnimation.PlayAnimationRun;
        _inputReader.ClickedUpDirection -= _heroKnightMovement.Jump;
        _inputReader.ClickedUpDirection -= _heroKnightAnimation.PlayAnimationJump;
        _inputReader.ClickedFButton -= _heroKnightAnimation.PlayAnimationAttack;
        _inputReader.ClickedFButton -= StartAttack;
        _inputReader.ClickedRButton -= _vampirism.EnableSpell;
        _coinDetector.DetectedCoin -= IncreaseCountCoin;
        _attackRange.DetectedHealth -= Attack;
        _firstAidKitDetector.DetectedFirstAidKit -= _healthComponent.Heal;
        _vampirismRange.DetectedHealth -= _vampirism.AddTarget;
        _vampirismRange.MissedHealth -= _vampirism.RemoveTarget;
        _vampirism.StealedHealth -= _healthComponent.Heal;
        _vampirism.EnabledSpell -= EnableVampirism;
        _vampirism.DisabledSpell -= DisableVampirism;
    }

    private void Start()
    {
        _attackRange.gameObject.SetActive(false);
        _vampirismRange.gameObject.SetActive(false);
    }
    
    public void EnableVampirism()
    {
        _vampirismRange.gameObject.SetActive(true);
    }

    public void DisableVampirism()
    {
        _vampirismRange.gameObject.SetActive(false);
    }

    public void StartAttack()
    {
        _attackRange.gameObject.SetActive(true);
    }

    private void Attack(HealthComponent health)
    {
        _heroKnightAttack.Attack(health);
        _attackRange.gameObject.SetActive(false);
    }

    private void IncreaseCountCoin(float countCoin)
    {
        _countCoin += countCoin;
        Debug.LogFormat($"Количество монет:{_countCoin}");
    }
}