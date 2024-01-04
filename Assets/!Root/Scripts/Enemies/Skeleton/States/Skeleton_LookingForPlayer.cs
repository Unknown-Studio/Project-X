using Suhdo.StateMachineCore;

namespace Suhdo.Enemies.Skeleton
{
    public class Skeleton_LookingForPlayer : EnemyLookingForPlayer
    {
        private Skeleton _skeleton;
        
        public Skeleton_LookingForPlayer(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyLookingForPlayer data) : base(stateMachine, entity, animBoolName, data)
        {
            _skeleton = (Skeleton)entity;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(_skeleton.PlayerDetectedState);
            }
            else if (isAllTurnsTimeDone)
            {
                stateMachine.ChangeState(_skeleton.MoveState);
            }
        }
    }
}
