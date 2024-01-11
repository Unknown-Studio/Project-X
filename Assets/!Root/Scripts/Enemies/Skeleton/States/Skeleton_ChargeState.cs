using Suhdo.StateMachineCore;

namespace Suhdo.Enemies.Skeleton
{
    public class Skeleton_ChargeState : EnemyChargeState
    {
        private Skeleton _skeleton;
        
        public Skeleton_ChargeState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyChargeState data) : base(stateMachine, entity, animBoolName, data)
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
            else if (!isDetectingLedge || isDetectingWall)
            {
                stateMachine.ChangeState(_skeleton.LookingForPlayer);
            }
            else if (isChargeTimeOver)
            {
                if (isPlayerInMinAgroRange)
                {
                    stateMachine.ChangeState(_skeleton.PlayerDetectedState);
                }
                else if(!isPlayerInMaxAgroRange)
                {
                    stateMachine.ChangeState(_skeleton.LookingForPlayer);
                }
            }
        }
    }
}
