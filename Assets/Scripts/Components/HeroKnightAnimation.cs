using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HeroKnightAnimation : MonoBehaviour
{
    private readonly string MoveVelocity = nameof(MoveVelocity);
    private readonly string JumpVelocity = nameof(JumpVelocity);
    private readonly string Attack = nameof(Attack);

    private Animator _animator;

    private bool _isIdle = true;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimationRun(float moveVelocity)
    {
        _animator.SetFloat(MoveVelocity, Mathf.Abs(moveVelocity));

        if (_isIdle == true && Mathf.Abs(moveVelocity) > 0)
        {
            _isIdle = false;
        }
        else if (moveVelocity == 0 && _isIdle == false)
        {
            _isIdle = true;
        }
    }

    public void PlayAnimationJump(float jumpVelocity)
    {
        _animator.SetFloat(JumpVelocity, Mathf.Abs(jumpVelocity));

        if (_isIdle == true && Mathf.Abs(jumpVelocity) > 0)
        {
            _isIdle = false;
        }
        else if (jumpVelocity == 0 && _isIdle == false)
        {
            _isIdle = true;
        }
    }

    public void PlayAnimationAttack()
    {
        _animator.SetTrigger(Attack);
    }
}