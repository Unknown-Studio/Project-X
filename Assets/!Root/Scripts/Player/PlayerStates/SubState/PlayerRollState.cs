using Suhdo.Player;
using Suhdo.StateMachineCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suhdo
{
    public class PlayerRollState : PlayerGroundState
    {
        public PlayerRollState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data) : base(stateMachine, entity, animBoolName, data)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.InputHandler.UserRollInput();
            PlayerCore.PlayerMovement.SetVelocityX(playerData.RollVelocity * PlayerCore.PlayerMovement.FacingDirection);
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (yInput == 1f)
                stateMachine.ChangeState(player.JumpState);
            if (isAnimationFinished)
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }
    }
}
