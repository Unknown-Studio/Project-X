using Suhdo.StateMachineCore;

namespace Suhdo.Enemies.Huntress
{
    public class Huntress_FallState : EnemyFallState
    {
        private Huntress _huntress;
        
        public Huntress_FallState(StateMachine stateMachine, Entity entity, string animBoolName)
            : base(stateMachine, entity, animBoolName)
        {
            _huntress = (Huntress)enemy;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if(isDetectingGround)
                stateMachine.ChangeState(_huntress.IdleState);
        }
    }
}
