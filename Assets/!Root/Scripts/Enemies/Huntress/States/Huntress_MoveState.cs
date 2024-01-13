using Suhdo.StateMachineCore;

namespace Suhdo.Enemies.Huntress
{
    public class Huntress_MoveState : EnemyMoveState
    {
        private Huntress _huntress;
        public Huntress_MoveState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyMoveState data) 
            : base(stateMachine, entity, animBoolName, data)
        {
            _huntress = (Huntress)enemy;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (isPlayerInMinAgroRange)
                stateMachine.ChangeState(_huntress.PlayerDetectedState);
            else if(!isDetectingGround)
                stateMachine.ChangeState(_huntress.FallState);
            else if (isDetectingWall || !isDetectingLedge || isTimeOut)
            {
                _huntress.IdleState.SetFlipAfterIdle(!isTimeOut);
                stateMachine.ChangeState(_huntress.IdleState);
            }
        }
    }
}
