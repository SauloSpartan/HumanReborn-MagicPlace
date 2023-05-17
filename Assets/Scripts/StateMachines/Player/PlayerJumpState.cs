using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactor) : base(currentContext, playerStateFactor)
    {

    }

    public override void EnterState()
    {
        _ctx.Animator.Play("Jump");
        _ctx.RigidBody.velocity = new Vector2(_ctx.RigidBody.velocity.x, 0);
        _ctx.RigidBody.AddForce(Vector2.up * _ctx.JumpForce, ForceMode2D.Impulse);
        _ctx.MaxJumps -= 1;
        _ctx.IsJumping = true;
    }

    public override void UpdateState()
    {
        Move();
        Jump();
        CheckSwitchState();
    }

    public override void ExitState()
    {
        
    }

    public override void CheckSwitchState()
    {
        if (_ctx.ClickButton == true)
        {
            SwitchState(_factory.Attack());
        }
    }

    private void Move()
    {
        _ctx.RigidBody.velocity = new Vector2(_ctx.MoveInX * _ctx.Speed, _ctx.RigidBody.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _ctx.MaxJumps > 0)
        {
            _ctx.Animator.Play("Jump");
            _ctx.RigidBody.velocity = new Vector2(_ctx.RigidBody.velocity.x, 0);
            _ctx.RigidBody.AddForce(Vector2.up * _ctx.JumpForce, ForceMode2D.Impulse);
            _ctx.MaxJumps -= 1;
        }
    }
}