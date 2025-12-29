using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(BirdCollisionDetector))]
[RequireComponent(typeof(ScoreCounter))]
public class Bird : MonoBehaviour
{
    [SerializeField] private BirdMover _birdMover;
    [SerializeField] private BirdCollisionDetector _birdCollisionDetector;
    [SerializeField] private ScoreCounter _scoreCounter;

    public event Action GameOver;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _birdCollisionDetector = GetComponent<BirdCollisionDetector>();
        _birdMover = GetComponent<BirdMover>();
    }

    private void OnEnable()
    {
        _birdCollisionDetector.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _birdCollisionDetector.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Enemy || interactable is Ground)
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
