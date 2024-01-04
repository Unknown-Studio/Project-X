using Suhdo.StateMachineCore;

namespace Suhdo.Enemies.Skeleton
{
    public class Skeleton_FallState : EnemyFallState
    {
        private Skeleton _skeleton;
        public Skeleton_FallState(StateMachine stateMachine, Entity entity, string animBoolName) : base(stateMachine, entity, animBoolName)
        {
            _skeleton = (Skeleton)entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if(isDetectingGround)
                stateMachine.ChangeState(_skeleton.IdleState);
        }
    }
}
