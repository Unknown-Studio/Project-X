using Suhdo.Player;
using Suhdo.StateMachineCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Suhdo
{
    public class PlayerWallSlideState : PlayerTouchingWallState
    {
        private int _xinput;
        private int _yinput;
        public PlayerWallSlideState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data) : base(stateMachine, entity, animBoolName, data)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            _xinput = player.InputHandler.NormInputX;
            _yinput = player.InputHandler.NormInputY;
            if ((iswall && _xinput == 1f || iswall && _xinput == -1f) && !isGrounded)
            {
                stateMachine.ChangeState(player.WallSlideState);
            }
            else
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            PlayerCore.PlayerMovement.SetVelocityY(-3f);
        }
    }
}
