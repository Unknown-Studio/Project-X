using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Player
{
    public class PlayerTouchingWallState : PlayerState
    {
        protected bool isGrounded;
        protected bool isTouchingWallFront;
        protected bool isTouchingWallBack;
        protected bool grabInput;
        protected bool jumpInput;
        protected bool isTouchingLedge;

        protected int xInput;
        protected int yInput;
        
        public PlayerTouchingWallState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data) : base(stateMachine, entity, animBoolName, data)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();

            isGrounded = Core.CollisionSenses.Ground;
            isTouchingWallFront = Core.CollisionSenses.WallFront;
			isTouchingWallBack = PlayerCore.PlayerCollisionSenses.WallBack;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            xInput = player.InputHandler.NormInputX;
            yInput = player.InputHandler.NormInputY;
            jumpInput = player.InputHandler.JumpInput;

            // Change state here
        }
    }
}
