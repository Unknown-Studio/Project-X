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
            
            if (xInput == 0 || !isTouchingWallFront)
            {
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
            Movement.SetVelocityY(-3f);
        }
    }
}
