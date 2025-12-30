using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour, IInteractable
{
    [SerializeField] private float _speed;

    private bool _direction;

    private Rigidbody2D _rigidbody;

    public event Action<Projectile> ObjectDestroyed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void DestroyObject(Projectile projectile)
    {
        ObjectDestroyed?.Invoke(projectile);
    }

    private void Update()
    {
        Vector2 newPosition = new Vector2(_rigidbody.position.x + _speed, _rigidbody.position.y);

        _rigidbody.position = Vector2.MoveTowards(_rigidbody.position, newPosition, Mathf.Abs(_speed * Time.deltaTime));
    }

    public void ChangeDirection(bool direction)
    {
        _direction = direction;

        if (_direction == true)
        {
            if(_speed > 0)
            {
                _speed = -_speed;
            }
        }
    }
}
