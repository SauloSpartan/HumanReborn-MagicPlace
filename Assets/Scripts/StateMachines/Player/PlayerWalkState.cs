using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{

    public PlayerWalkState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactor) : base(currentContext, playerStateFactor)
    {

    }

    public override void EnterState()
    {
        _ctx.Animator.Play("Walk");
    }

    public override void UpdateState()
    {   
        _ctx.RigidBody.velocity = new Vector2(_ctx.MoveInX * _ctx.Speed, _ctx.RigidBody.velocity.y);
        CheckSwitchState();
    }

    public override void ExitState()
    {

    }

    public override void CheckSwitchState()
    {
        if (_ctx.MoveInX == 0)
        {
            SwitchState(_factory.Idle());
        }
        else if (_ctx.JumpKey == true && _ctx.MaxJumps > 0)
        {
            SwitchState(_factory.Jump());
        }
        else if (_ctx.ClickButton == true)
        {
            SwitchState(_factory.Attack());
        }
    }
}