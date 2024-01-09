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
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (isAnimationFinished)
            {
                if (!_isCeiling)
                {
                    stateMachine.ChangeState(player.IdleState);
                }
                else
                {
                    stateMachine.ChangeState(player.CrouchIdleState);

                }
            }
        }
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            PlayerCore.PlayerMovement.SetVelocityX(playerData.RollVelocity * PlayerCore.PlayerMovement.FacingDirection);
        }
    }
}
