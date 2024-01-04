using Suhdo.StateMachineCore;

namespace Suhdo.Enemies.Skeleton
{
    public class Skeleton_IdleState : EnemyIdleState
    {
        private Skeleton _skeleton;
        
        public Skeleton_IdleState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyIdleState data) : base(stateMachine, entity, animBoolName, data)
        {
            _skeleton = (Skeleton)entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isPlayerInMinAgroRange)
                stateMachine.ChangeState(_skeleton.PlayerDetectedState);
            else if(!isDetectingGround)
                stateMachine.ChangeState(_skeleton.FallState);
            else if (isIdleTimeOver)
                stateMachine.ChangeState(_skeleton.MoveState);
        }
    }
}
