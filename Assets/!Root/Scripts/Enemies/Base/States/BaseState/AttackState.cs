using Suhdo.StateMachineCore;
using UnityEngine;

namespace Suhdo.Enemies
{
    public class AttackState : EnemyState, IAttackState
    {
        protected bool isAnimationFinished;
        protected bool isPlayerInMinAgroRange;
        
        public AttackState(StateMachine stateMachine, Entity entity, string animBoolName)
            : base(stateMachine, entity, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();

            isPlayerInMinAgroRange = enemy.Core.CollisionSenses.PlayerInMinAgroRange;
        }

        public override void Enter()
        {
            base.Enter();

            enemy.AnimToStateMachine.AttackState = this;
            isAnimationFinished = false;
            enemy.Core.Movement.SetVelocityZero();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            
            enemy.Core.Movement.SetVelocityZero();
        }

        public virtual void TriggerAttack()
        {
            
        }

        public virtual void FinishAttack()
        {
            isAnimationFinished = true;
        }
    }
}
