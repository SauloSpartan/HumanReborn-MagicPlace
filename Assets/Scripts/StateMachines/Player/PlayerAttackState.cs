using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public PlayerAttackState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactor) : base(currentContext, playerStateFactor)
    {

    }

    public override void EnterState()
    {
        _ctx.Animator.Play("Attack");
        _ctx.IsJumping = false;

        /*AnimatorClipInfo[] currentClipInfo;
        currentClipInfo = _ctx.Animator.GetCurrentAnimatorClipInfo(0);
        _ctx.AnimationLength = currentClipInfo[0].clip.length;*/
        _ctx.AnimationLength = 0.80f;
    }

    public override void UpdateState()
    {
        MoveAndJump();
        if (_ctx.AnimationLength > 0)
        {
            _ctx.AnimationLength -= Time.deltaTime;
        }
        CheckSwitchState();
    }

    public override void ExitState()
    {

    }

    public override void CheckSwitchState()
    {
        if (_ctx.AnimationLength <= 0)
        {
            SwitchState(_factory.Idle());
        }
    }

    private void MoveAndJump()
    {
        _ctx.RigidBody.velocity = new Vector2(_ctx.MoveInX * _ctx.Speed, _ctx.RigidBody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && _ctx.MaxJumps > 0)
        {
            _ctx.RigidBody.velocity = new Vector2(_ctx.RigidBody.velocity.x, 0);
            _ctx.RigidBody.AddForce(Vector2.up * _ctx.JumpForce, ForceMode2D.Impulse);
            _ctx.MaxJumps -= 1;
        }
    }
}