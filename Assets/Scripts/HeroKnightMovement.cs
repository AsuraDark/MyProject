using System;
using UnityEngine;

public class HeroKnightMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed;

    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    public event Action<float> MovedHeroKnight;
    public event Action<float> JumpedHeroKnight;

    private void Update()
    {
        float directionHorizontal = Input.GetAxis(Horizontal);
        float directionVertical = Input.GetAxis(Vertical);

        if (directionHorizontal >= 0 || directionHorizontal <= 0)
        {
            transform.Translate(directionHorizontal * _moveSpeed * Time.deltaTime * Vector3.right);
            MovedHeroKnight?.Invoke(directionHorizontal);
        }

        if (directionVertical >= 0)
        {
            transform.Translate(directionVertical * _jumpSpeed * Time.deltaTime * Vector3.up);
            JumpedHeroKnight?.Invoke(directionVertical);
        }
    }
}
