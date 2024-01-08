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
            
            /*if (performCloseRangeAction)
            {
                //TODO: change to attack state
            }
            else if (performLongRangeAction)
            {
                //TODO: change to charge state
            }
            else*/ if (!isPlayerInMaxAgroRange)
            {
                //TODO: change to looking for player
                stateMachine.ChangeState(_huntress.LookingForPlayer);
            }
            else if (!isDetectingLedge)
            {
                _huntress.EnemyCore.EnemyMovement.Flip();
                stateMachine.ChangeState(_huntress.MoveState);
            }
        }
    }
}
