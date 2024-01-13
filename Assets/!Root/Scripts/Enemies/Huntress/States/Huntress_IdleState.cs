using Suhdo.Enemies;
using Suhdo.Enemies.Huntress;
using Suhdo.StateMachineCore;

namespace Suhdo
{
    public class Huntress_IdleState : EnemyIdleState
    {
        private Huntress _huntress;
        
        public Huntress_IdleState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyIdleState data)
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
            else if(isIdleTimeOver)
                stateMachine.ChangeState(_huntress.MoveState);
        }

        
    }
}
