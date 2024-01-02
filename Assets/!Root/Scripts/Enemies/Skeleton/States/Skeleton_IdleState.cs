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
            {
                //Change to Detected state
            }
            else if (isIdleTimeOver)
            {
                //Change to Move state
            }
        }
    }
}
