using Suhdo.StateMachineCore;

namespace Suhdo.Enemies.Skeleton
{
    public class Skeleton_PlayerDetectedState : EnemyPlayerDetectedState
    {
        private Skeleton _skeleton;
        
        public Skeleton_PlayerDetectedState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyPlayerDetectedState data) : base(stateMachine, entity, animBoolName, data)
        {
            _skeleton = (Skeleton)entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (performCloseRangeAction)
            {
                // Change to melee attack state
            }
            else if (performLongRangeAction)
            {
                // Change to charge state
            }
            else if (!isPlayerInMaxAgroRange)
            {
                // Change to Looking for player state
                stateMachine.ChangeState(_skeleton.IdleState);
            }
            else if (!isDetectingLedge)
            {
                _skeleton.EnemyCore.EnemyMovement.Flip();
                stateMachine.ChangeState(_skeleton.MoveState);
            }
        }
    }
}
