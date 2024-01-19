using Suhdo.StateMachineCore;

namespace Suhdo.Player
{
    public class PlayerWallSlideState : PlayerTouchingWallState
    {
        private int _xInput;
        private int _yInput;
        public PlayerWallSlideState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data) : base(stateMachine, entity, animBoolName, data)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            _xInput = player.InputHandler.NormInputX;
            _yInput = player.InputHandler.NormInputY;
            if ((isTouchingWallBack && _xInput == 1f || isTouchingWallBack && _xInput == -1f) && !isGrounded)
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
