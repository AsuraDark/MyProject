using UnityEngine;

[RequireComponent(typeof(HeroKnightMovement), typeof(Animator))]
public class HeroKnight : MonoBehaviour
{
    [SerializeField] private CoinDetector _coinDetector;

    private HeroKnightMovement _heroKnightMovement;
    private Animator _animator;

    private readonly string MoveVelocity = nameof(MoveVelocity);
    private readonly string JumpVelocity = nameof(JumpVelocity);

    private bool _isIdle = true;

    private int _countCoin = 0;

    private void Awake()
    {
        _heroKnightMovement = GetComponent<HeroKnightMovement>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _heroKnightMovement.MovedHeroKnight += PlayAnimationRun;
        _heroKnightMovement.JumpedHeroKnight += PlayAnimationJump;
        _coinDetector.DetectedCoin += IncreaseCountCoin;
    }

    private void OnDisable()
    {
        _heroKnightMovement.MovedHeroKnight -= PlayAnimationRun;
        _heroKnightMovement.JumpedHeroKnight -= PlayAnimationJump;
        _coinDetector.DetectedCoin -= IncreaseCountCoin;
    }

    private void PlayAnimationRun(float moveVelocity)
    {
        _animator.SetFloat(MoveVelocity, Mathf.Abs(moveVelocity));

        if(_isIdle == true && Mathf.Abs(moveVelocity) > 0)
        {
            _isIdle = false;
        }
        else if(moveVelocity == 0)
        {
            _isIdle = true;
        }
    }

    private void PlayAnimationJump(float jumpVelocity)
    {
        _animator.SetFloat(JumpVelocity, Mathf.Abs(jumpVelocity));

        if (_isIdle == true && Mathf.Abs(jumpVelocity) > 0)
        {
            _isIdle = false;
        }
        else if (jumpVelocity == 0)
        {
            _isIdle = true;
        }
    }

    private void IncreaseCountCoin()
    {
        _countCoin++;
        Debug.LogFormat("Количество монет:{0}", _countCoin);
    }
}
