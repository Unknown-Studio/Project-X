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
                stateMachine.ChangeState(_skeleton.MeleeAttackState);
            }
            else if (performLongRangeAction)
            {
                stateMachine.ChangeState(_skeleton.ChargeState);
            }
            else if (!isPlayerInMaxAgroRange)
            {
                stateMachine.ChangeState(_skeleton.LookingForPlayer);
            }
            else if (!isDetectingLedge)
            {
                _skeleton.Core.Movement.Flip();
                stateMachine.ChangeState(_skeleton.MoveState);
            }
        }
    }
}
