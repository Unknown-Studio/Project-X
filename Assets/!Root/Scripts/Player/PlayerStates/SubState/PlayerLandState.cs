using Suhdo.StateMachineCore;

namespace Suhdo.Player
{
    public class PlayerLandState : PlayerGroundState
    {
        public PlayerLandState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data) : base(stateMachine, entity, animBoolName, data)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if(xInput != 0)
                stateMachine.ChangeState(player.MoveState);
            else if(isAnimationFinished)
                stateMachine.ChangeState(player.IdleState);
            else if(yInput == -1)
                stateMachine.ChangeState(player.CrouchIdleState);
        }
    }
}
