using System;
using UnityEngine;

public class HeroKnightMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed;

    public void Move(float directionHorizontal)
    {
        transform.Translate(directionHorizontal * _moveSpeed * Time.deltaTime * Vector3.right, Space.World);
        ChangeRotation(directionHorizontal);
    }
    
    public void Jump(float directionVertical)
    {
        transform.Translate(directionVertical * _jumpSpeed * Time.deltaTime * Vector3.up);
    }

    private void ChangeRotation(float directionVertical)
    {
        if (directionVertical > 0 && transform.eulerAngles.y == 180)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
        }
        else if (directionVertical < 0 && transform.eulerAngles.y == 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
        }
    }
}