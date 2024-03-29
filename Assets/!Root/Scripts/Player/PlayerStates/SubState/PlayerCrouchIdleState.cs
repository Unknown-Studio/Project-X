using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Player
{
    public class PlayerCrouchIdleState : PlayerGroundState
    {
        public PlayerCrouchIdleState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data) : base(stateMachine, entity, animBoolName, data)
        {
        }
        public override void Enter()
        {
            base.Enter();
            Movement.SetVelocityX(0f);
            player.SetColliderHeight(playerData.crouchColliderHeight);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isExitingState) return;

            if (xInput != 0f &&( yInput == -1f || _isCeiling)) stateMachine.ChangeState(player.CrouchMoveState);
            else if (xInput == 0f && yInput == 0f && !_isCeiling) stateMachine.ChangeState(player.IdleState);
            else if (xInput != 0f && yInput == 0f && !_isCeiling) stateMachine.ChangeState(player.MoveState);
        }

        public override void Exit()
        {
            base.Exit();
            player.SetColliderHeight(playerData.standColliderHeight);
        }
    }
}
