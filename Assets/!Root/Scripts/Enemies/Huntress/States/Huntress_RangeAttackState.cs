using Suhdo.StateMachineCore;

namespace Suhdo.Enemies.Huntress
{
    public class Huntress_RangeAttackState : RangeAttackState
    {
        private Huntress _huntress;
        public Huntress_RangeAttackState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyRangeAttackState data)
            : base(stateMachine, entity, animBoolName, data)
        {
            _huntress = (Huntress)enemy;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!isAnimationFinished) return;
            
            if (isPlayerInMinAgroRange || isPlayerInMaxAgroRange)
            {
                stateMachine.ChangeState(_huntress.PlayerDetectedState);
            }
            else if(!isPlayerInMaxAgroRange)
            {
                stateMachine.ChangeState(_huntress.LookingForPlayer);
            }
        }
    }
}
