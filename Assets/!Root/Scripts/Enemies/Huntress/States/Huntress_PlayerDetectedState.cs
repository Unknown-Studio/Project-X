using Suhdo.StateMachineCore;

namespace Suhdo.Enemies.Huntress
{
    public class Huntress_PlayerDetectedState : EnemyPlayerDetectedState
    {
        private Huntress _huntress;
        
        public Huntress_PlayerDetectedState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyPlayerDetectedState data)
            : base(stateMachine, entity, animBoolName, data)
        {
            _huntress = (Huntress)enemy;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if(isPlayerInMinAgroRange)
                stateMachine.ChangeState(_huntress.RangeAttackState);
            /*else if (performCloseRangeAction)
            {
                //TODO: change to charge state
            }*/
            else if (isPlayerInMaxAgroRange)
                stateMachine.ChangeState(_huntress.MoveState);
            else if (!isPlayerInMaxAgroRange)
                stateMachine.ChangeState(_huntress.LookingForPlayer);
            
            if (!isDetectingLedge)
            {
                _huntress.EnemyCore.EnemyMovement.Flip();
                stateMachine.ChangeState(_huntress.MoveState);
            }
        }
    }
}
