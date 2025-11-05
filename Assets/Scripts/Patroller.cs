using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private Vector3[] _targetPositions;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxInaccuracy;

    private int _currentIndexPosition = 0;

    private void Update()
    {
        Vector3 direction = (_targetPositions[_currentIndexPosition] - transform.position).normalized;

        transform.Translate(_speed * Time.deltaTime * direction);

        if (Mathf.Abs(_targetPositions[_currentIndexPosition].x - transform.position.x) <= _maxInaccuracy)
        {
            _currentIndexPosition = ++_currentIndexPosition % _targetPositions.Length;
        }
    }
}
