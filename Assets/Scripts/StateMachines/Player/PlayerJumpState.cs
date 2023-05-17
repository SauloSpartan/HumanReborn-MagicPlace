using TMPro;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactor) : base(currentContext, playerStateFactor)
    {

    }

    public override void EnterState()
    {
        _ctx.Animator.Play("Jump_1");
        _ctx.RigidBody.velocity = new Vector2(_ctx.RigidBody.velocity.x, 0);
        _ctx.RigidBody.AddForce(Vector2.up * _ctx.JumpForce, ForceMode2D.Impulse);
        _ctx.MaxJumps -= 1;
    }

    public override void UpdateState()
    {
        Jump();
        CheckSwitchState();
    }

    public override void ExitState()
    {

    }

    public override void CheckSwitchState()
    {
        if (_ctx.JumpKey == false || _ctx.IsGrounded() == true) 
        {
            SwitchState(_factory.Idle());
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _ctx.MaxJumps > 0)
        {
            _ctx.RigidBody.velocity = new Vector2(_ctx.RigidBody.velocity.x, 0);
            _ctx.RigidBody.AddForce(Vector2.up * _ctx.JumpForce, ForceMode2D.Impulse);
            _ctx.MaxJumps -= 1;
        }
    }
}
