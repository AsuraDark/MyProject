using System;
using UnityEngine;

public class HeroKnightMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed;

    public void Move(float directionHorizontal)
    {
        transform.Translate(directionHorizontal * _moveSpeed * Time.deltaTime * Vector3.right);
    }
    
    public void Jump(float directionVertical)
    {
        transform.Translate(directionVertical * _jumpSpeed * Time.deltaTime * Vector3.up);
    }
}