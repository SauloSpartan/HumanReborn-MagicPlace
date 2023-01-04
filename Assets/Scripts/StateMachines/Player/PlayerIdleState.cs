using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactor) : base (currentContext, playerStateFactor)
    {

    }

    public override void EnterState()
    {
        _ctx.Animator.Play("Idle");
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
        if (_ctx.MoveInX != 0)
        {
            SwitchState(_factory.Walk());
        }
        else if (_ctx.JumpKey == true && _ctx.IsGrounded() == true)
        {
            SwitchState(_factory.Jump());
        }
    }
}
