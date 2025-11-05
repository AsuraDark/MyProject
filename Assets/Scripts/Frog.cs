using UnityEngine;

public class Frog : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rangePatrol;

    private Vector3 _firstPosition;
    private Vector3 _secondPosition;

    private void Awake()
    {
        _firstPosition = new Vector3(transform.position.x + _rangePatrol, transform.position.y, transform.position.z);
        _secondPosition = new Vector3(transform.position.x - _rangePatrol, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime* Vector3.right);

        if(transform.position.x >= _firstPosition.x)
        {
            _speed = -_speed;
        }
        else if (transform.position.x <= _secondPosition.x)
        {
            _speed = -_speed;
        }
    }
}
