using System.Collections;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private Vector3[] _targetPositions;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxInaccuracy;

    private int _currentIndexPosition = 0;

    public IEnumerator StartPatroll()
    {
        while (enabled)
        {
            if (_targetPositions.Length == 0)
                yield return null;

            if (Mathf.Abs(_targetPositions[_currentIndexPosition].x - transform.position.x) <= _maxInaccuracy)
            {
                if (_targetPositions.Length == 1)
                    yield return null;

                _currentIndexPosition = ++_currentIndexPosition % _targetPositions.Length;

                ChangeRotation(_targetPositions[_currentIndexPosition]);
            }

            Vector3 direction = ChangeDirection(_targetPositions[_currentIndexPosition]);

            transform.Translate(_speed * Time.deltaTime * direction);
            yield return null;
        }
    }

    public IEnumerator StartFollowTarget(Vector3 target)
    {
        while (enabled)
        {
            Vector3 direction = ChangeDirection(target);

            transform.Translate(_speed * Time.deltaTime * direction);
            yield return null;
        }
    }

    private void ChangeRotation(Vector3 target)
    {
        if (target.x < transform.position.x && transform.eulerAngles.y == 180)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
            _speed = -_speed;
        }
        else if (target.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            _speed = -_speed;
        }
    }

    private Vector3 ChangeDirection(Vector3 target)
    {
        return (target - transform.position).normalized;
    }
}
