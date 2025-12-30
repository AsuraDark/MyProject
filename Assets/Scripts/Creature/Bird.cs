using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(BirdCollisionDetector))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(BirdAttacker))]
public class Bird : MonoBehaviour
{
    private BirdMover _birdMover;
    private BirdAttacker _birdAttacker;
    private BirdCollisionDetector _birdCollisionDetector;
    private ScoreCounter _scoreCounter;
    private InputReader _inputReader;

    public event Action GameOver;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _birdAttacker = GetComponent<BirdAttacker>();
        _birdCollisionDetector = GetComponent<BirdCollisionDetector>();
        _birdMover = GetComponent<BirdMover>();
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _birdCollisionDetector.CollisionDetected += ProcessCollision;
        _inputReader.ClickedButtonSpace += _birdMover.Jump;
        _inputReader.ClickedButtonR += _birdAttacker.Attack;
    }

    private void OnDisable()
    {
        _birdCollisionDetector.CollisionDetected -= ProcessCollision;
        _inputReader.ClickedButtonSpace -= _birdMover.Jump;
        _inputReader.ClickedButtonR -= _birdAttacker.Attack;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Enemy || interactable is Ground || interactable is Projectile)
        {
            GameOver?.Invoke();
        }

        else if (interactable is ScoreZone)
        {
            _scoreCounter.Add();
        }
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _birdMover.Reset();
    }
}
