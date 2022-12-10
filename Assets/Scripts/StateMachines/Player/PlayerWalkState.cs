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
        _ctx.RigidBody.velocity = new Vector2(_ctx.MoveX * _ctx.Speed, _ctx.RigidBody.velocity.y);
        CheckSwitchState();
    }

    public override void ExitState()
    {

    }

    public override void CheckSwitchState()
    {
        if (_ctx.MoveX == 0)
        {
            SwitchState(_factory.Idle());
        }
    }
}