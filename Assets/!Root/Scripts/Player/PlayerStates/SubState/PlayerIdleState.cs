using Suhdo.StateMachineCore;

namespace Suhdo.Player
{
    public class PlayerIdleState : PlayerGroundState
    {
        public PlayerIdleState(StateMachine stateMachine, Entity entity, string animBoolName, PlayerData data) 
            : base(stateMachine, entity, animBoolName, data)
        {
        }

        public override void Enter()
        {
            base.Enter();
            PlayerCore.PlayerMovement.SetVelocityX(0f);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (isExitingState) return;
            
            if(xInput != 0) stateMachine.ChangeState(player.MoveState);
            if(yInput == -1) stateMachine.ChangeState(player.CrouchIdleState);
        }
    }
}
