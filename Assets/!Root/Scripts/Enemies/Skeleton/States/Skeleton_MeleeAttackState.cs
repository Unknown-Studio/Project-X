using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Enemies.Skeleton
{
    public class Skeleton_MeleeAttackState : MeleeAttackState
    {
        private Skeleton _skeleton;
        public Skeleton_MeleeAttackState(StateMachine stateMachine, Entity entity, string animBoolName, D_EnemyMeleeAttack data)
            : base(stateMachine, entity, animBoolName, data)
        {
            _skeleton = (Skeleton)enemy;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (!isDetectingGround)
            {
                stateMachine.ChangeState(_skeleton.FallState);
            }

            if (!isAnimationFinished) return;

            if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(_skeleton.PlayerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(_skeleton.LookingForPlayer);
            }
        }
    }
}
