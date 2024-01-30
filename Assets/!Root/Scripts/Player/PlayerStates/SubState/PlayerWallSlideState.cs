using Suhdo.StateMachineCore;

namespace Suhdo.Player
{
    public class PlayerWallSlideState : PlayerTouchingWallState
    {
        public PlayerWallSlideState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data) : base(stateMachine, entity, animBoolName, data)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (xInput == 0 || xInput + Movement.FacingDirection == 0 || !isTouchingWallFront)
            {
                Movement.Flip();
                stateMachine.ChangeState(player.InAirState);
            }
            else if(isGrounded)
            {
                stateMachine.ChangeState(player.LandState);
            }
        }
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            Movement.SetVelocityY(playerData.WallSlideVelocity);
        }
    }
}
