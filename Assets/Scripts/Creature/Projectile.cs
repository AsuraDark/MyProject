using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : Interactable
{
    [SerializeField] private float _speed;

    private const float RotationRight = 0;
    private const float RotationLeft = 180;

    private Rigidbody2D _rigidbody;

    public event Action<Projectile> ObjectDestroyed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 newPosition = transform.position;

        if (transform.eulerAngles.y == RotationLeft)
        {
            newPosition = new Vector2(_rigidbody.position.x - _speed, _rigidbody.position.y);
        }
        else if (transform.eulerAngles.y == RotationRight)
        {
            newPosition = new Vector2(_rigidbody.position.x + _speed, _rigidbody.position.y);
        }

        _rigidbody.position = Vector2.MoveTowards(_rigidbody.position, newPosition, Mathf.Abs(_speed * Time.deltaTime));
    }

    public void ChangeRotation(float rotationY)
    {
        if(rotationY != transform.eulerAngles.y)
        {
            transform.Rotate(transform.eulerAngles.x, rotationY, transform.eulerAngles.z);
        }
    }
    public void DestroyObj()
    {
        ObjectDestroyed?.Invoke(this);
    }
}
