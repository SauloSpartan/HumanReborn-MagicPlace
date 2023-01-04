using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactor) : base(currentContext, playerStateFactor)
    {

    }

    public override void EnterState()
    {
        _ctx.Animator.Play("Jump_1");
        _ctx.RemainJumps--;
        _ctx.RigidBody.velocity = new Vector2(_ctx.RigidBody.velocity.x, 0);
        _ctx.RigidBody.AddForce(Vector2.up * _ctx.JumpForce, ForceMode2D.Impulse);
    }

    public override void UpdateState()
    {   
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
}
