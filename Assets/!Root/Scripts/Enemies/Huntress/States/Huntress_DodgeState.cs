using Suhdo.StateMachineCore;

namespace Suhdo.Enemies.Huntress
{
    public class Huntress_DodgeState : EnemyDodgeState
    {
        private Huntress _huntress;
        
        public Huntress_DodgeState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyDodgeState data) : base(stateMachine, entity, animBoolName, data)
        {
            _huntress = (Huntress)enemy;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!isDodgeOver) return;
            if (isPlayerInMaxAgroRange && !performCloseRangeAction)
            {
                stateMachine.ChangeState(_huntress.RangeAttackState);
            }
            else if (!isPlayerInMaxAgroRange)
            {
                stateMachine.ChangeState(_huntress.LookingForPlayer);
            }
        }
    }
}
