using System;
using UnityEngine;

[RequireComponent(typeof(HeroKnightMovement), typeof(InputReader), typeof(HeroKnightAnimation))]
public class HeroKnight : MonoBehaviour
{
    [SerializeField] private CoinDetector _coinDetector;

    private HeroKnightMovement _heroKnightMovement;
    private HeroKnightAnimation _heroKnightAnimation;
    private InputReader _inputReader;

    private int _countCoin = 0;

    private void Awake()
    {
        _heroKnightMovement = GetComponent<HeroKnightMovement>();
        _inputReader = GetComponent<InputReader>();
        _heroKnightAnimation = GetComponent<HeroKnightAnimation>();
    }

    private void OnEnable()
    {
        _inputReader.ClickedAnyDirection += _heroKnightMovement.Move;
        _inputReader.ClickedAnyDirection += _heroKnightAnimation.PlayAnimationRun;
        _inputReader.ClickedUpDirection += _heroKnightMovement.Jump;
        _inputReader.ClickedUpDirection += _heroKnightAnimation.PlayAnimationJump;
        _coinDetector.DetectedCoin += IncreaseCountCoin;
    }

    private void OnDisable()
    {
        _inputReader.ClickedAnyDirection -= _heroKnightMovement.Move;
        _inputReader.ClickedAnyDirection -= _heroKnightAnimation.PlayAnimationRun;
        _inputReader.ClickedUpDirection -= _heroKnightMovement.Jump;
        _inputReader.ClickedUpDirection -= _heroKnightAnimation.PlayAnimationJump;
        _coinDetector.DetectedCoin -= IncreaseCountCoin;
    }

    private void IncreaseCountCoin()
    {
        _countCoin++;
        Debug.LogFormat("Количество монет:{0}", _countCoin);
    }
}